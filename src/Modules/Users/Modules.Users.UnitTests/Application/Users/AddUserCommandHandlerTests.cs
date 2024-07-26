using Common.Events;
using MassTransit;
using Modules.Users.Application.Common.Input;
using Modules.Users.Application.Common.Interfaces;
using Modules.Users.Application.Users.Commands.AddUser;
using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;
using Moq;

namespace Modules.Users.UnitTests.Application.Users;

[TestFixture]
public class AddUserCommandHandlerTests
{
    private Mock<IUserRepository> _mockUserRepository;
    private Mock<IAuth0Service> _mockAuth0Service;
    private Mock<IPublishEndpoint> _mockPublishEndpoint;
    private AddUserCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockAuth0Service = new Mock<IAuth0Service>();
        _mockPublishEndpoint = new Mock<IPublishEndpoint>();

        _handler = new AddUserCommandHandler(
            _mockUserRepository.Object,
            _mockAuth0Service.Object,
            _mockPublishEndpoint.Object);
    }

    [Test]
    public async Task Handle_ShouldReturnUserId_WhenUserIsSuccessfullyAdded()
    {
        // Arrange
        var input = new AddUserInput
        {
            Username = "testuser",
            Name = "Test User",
            Email = "test@example.com",
            Password = "securePassword",
            Bio = "This is a test user.",
            ProfilePictureBase64 = "base64string"
        };

        var command = new AddUserCommand(input);
        var auth0UserId = "auth0|12345";

        _mockAuth0Service
            .Setup(x => x.SignupUser(input.Email, input.Password))
            .ReturnsAsync(auth0UserId);

        _mockUserRepository
            .Setup(x => x.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        _mockPublishEndpoint
            .Setup(x => x.Publish(It.IsAny<UserCreatedEvent>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(auth0UserId, result);

        _mockAuth0Service.Verify(x => x.SignupUser(input.Email, input.Password), Times.Once);

        _mockUserRepository.Verify(
            x => x.AddAsync(It.Is<User>(u => u.Id == auth0UserId && u.Email == input.Email && u.Username == input.Username),
            It.IsAny<CancellationToken>()), Times.Once);

        _mockPublishEndpoint.Verify(
            x => x.Publish(It.Is<UserCreatedEvent>(e => e.UserId == auth0UserId),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}