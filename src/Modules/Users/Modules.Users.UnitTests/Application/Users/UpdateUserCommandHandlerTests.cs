using AutoMapper;
using Modules.Users.Application.Common.Errors;
using Modules.Users.Application.Common.Input;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Application.Users.Commands.UpdateUser;
using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;
using Moq;

namespace Modules.Users.UnitTests.Application.Users;

[TestFixture]
public class UpdateUserCommandHandlerTests
{
    private Mock<IUserRepository> _mockUserRepository;
    private Mock<IMapper> _mockMapper;
    private UpdateUserCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();

        _handler = new UpdateUserCommandHandler(
            _mockUserRepository.Object,
            _mockMapper.Object);
    }

    [Test]
    public async Task Handle_ShouldUpdateUser_WhenUserExists()
    {
        // Arrange
        var input = new UpdateUserInput
        {
            Id = "12345",
            Username = "updatedUsername",
            Name = "Updated Name",
            Bio = "Updated Bio",
            ProfilePictureBase64 = "newBase64String"
        };

        var command = new UpdateUserCommand(input);

        var existingUser = new User
        {
            Id = "12345",
            Username = "oldUsername",
            Name = "Old Name",
            Bio = "Old Bio",
            ProfilePictureBase64 = "oldBase64String"
        };

        _mockUserRepository
            .Setup(x => x.GetByIdAsync(input.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingUser);

        _mockUserRepository
            .Setup(x => x.UpdateAsync(existingUser.Id, existingUser, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var expectedUserPayload = new UserPayload
        {
            Id = existingUser.Id,
            Username = input.Username,
            Name = input.Name,
            Bio = input.Bio
        };

        _mockMapper
            .Setup(m => m.Map<UserPayload>(existingUser))
            .Returns(expectedUserPayload);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(expectedUserPayload, result.Data);

        _mockUserRepository.Verify(x => x.GetByIdAsync(input.Id, It.IsAny<CancellationToken>()), Times.Once);

        _mockUserRepository.Verify(
            x => x.UpdateAsync(
                existingUser.Id,
                It.Is<User>(u => u.Username == input.Username && u.Name == input.Name && u.Bio == input.Bio),
                It.IsAny<CancellationToken>()), Times.Once);

        _mockMapper.Verify(m => m.Map<UserPayload>(existingUser), Times.Once);
    }

    [Test]
    public async Task Handle_ShouldReturnFailureResponse_WhenUpdateFails()
    {
        // Arrange
        var input = new UpdateUserInput
        {
            Id = "12345",
            Username = "username",
            Name = "Name",
            Bio = "Bio"
        };

        var command = new UpdateUserCommand(input);

        var existingUser = new User
        {
            Id = "12345",
            Username = "oldUsername",
            Name = "Old Name",
            Bio = "Old Bio",
            ProfilePictureBase64 = "oldBase64String"
        };

        _mockUserRepository
            .Setup(x => x.GetByIdAsync(input.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingUser);

        _mockUserRepository
            .Setup(x => x.UpdateAsync(existingUser.Id, existingUser, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Update failed"));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(UserErrors.UpdateUserFailure, result.Error);
    }

    [Test]
    public async Task Handle_ShouldReturnFailureResponse_WhenInputIsNull()
    {
        // Arrange
        var command = new UpdateUserCommand(null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(UserErrors.InputIsNull, result.Error);
    }

    [Test]
    public async Task Handle_ShouldReturnFailureResponse_WhenUserNotFound()
    {
        // Arrange
        var input = new UpdateUserInput
        {
            Id = "12345",
            Username = "username",
            Name = "Name",
            Bio = "Bio"
        };

        var command = new UpdateUserCommand(input);

        _mockUserRepository
            .Setup(x => x.GetByIdAsync(input.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null);  // Simulate user not found

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(UserErrors.NotFound, result.Error);
    }
}