using AutoMapper;
using Modules.Posts.Application.Comments.Commands.UpdateComment;
using Modules.Posts.Application.Common.Errors;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;
using Moq;

namespace Modules.Posts.UnitTests.Application.Comments;

[TestFixture]
public class UpdateCommentCommandHandlerTests
{
    private Mock<ICommentRepository> _mockCommentRepository;
    private Mock<IMapper> _mockMapper;
    private UpdateCommentCommandHandler _sut;

    [SetUp]
    public void SetUp()
    {
        _mockCommentRepository = new Mock<ICommentRepository>();
        _mockMapper = new Mock<IMapper>();

        _sut = new UpdateCommentCommandHandler(_mockCommentRepository.Object, _mockMapper.Object);
    }

    [Test]
    public async Task Handle_ShouldUpdateCommentAndReturnPayload_WhenInputIsValid()
    {
        // Arrange
        var commentId = Guid.NewGuid();
        var input = new UpdateCommentInput
        {
            CommentId = commentId,
            Content = "Updated content"
        };

        var existingComment = new Comment
        {
            Id = commentId,
            Content = "Old content"
        };

        var updatedCommentPayload = new CommentPayload
        {
            Id = commentId,
            Content = "Updated content"
        };

        _mockCommentRepository.Setup(r => r.GetByIdAsync(commentId)).ReturnsAsync(existingComment);
        _mockMapper.Setup(m => m.Map<CommentPayload>(existingComment)).Returns(updatedCommentPayload);

        // Act
        var result = await _sut.Handle(new UpdateCommentCommand(input), CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(updatedCommentPayload, result.Data);

        _mockCommentRepository.Verify(r => r.UpdateAsync(commentId, existingComment, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task Handle_ShouldReturnFailureResponse_WhenInputIsNull()
    {
        // Arrange
        var command = new UpdateCommentCommand(null);

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(CommentErrors.NullInput, result.Error);
    }

    [Test]
    public async Task Handle_ShouldReturnFailureResponse_WhenCommentIdIsInvalid()
    {
        // Arrange
        var input = new UpdateCommentInput
        {
            CommentId = Guid.Empty, // Invalid CommentId
            Content = "Updated content"
        };

        var command = new UpdateCommentCommand(input);

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(CommentErrors.CommentIdRequired, result.Error);
    }

    [Test]
    public async Task Handle_ShouldReturnFailureResponse_WhenCommentDoesNotExist()
    {
        // Arrange
        var commentId = Guid.NewGuid();
        var input = new UpdateCommentInput
        {
            CommentId = commentId,
            Content = "Updated content"
        };

        _mockCommentRepository.Setup(r => r.GetByIdAsync(commentId)).ReturnsAsync((Comment)null);

        var command = new UpdateCommentCommand(input);

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(CommentErrors.NotFound, result.Error);
    }

    [Test]
    public async Task Handle_ShouldReturnFailureResponse_WhenContentIsNullOrWhiteSpace()
    {
        // Arrange
        var commentId = Guid.NewGuid();
        var input = new UpdateCommentInput
        {
            CommentId = commentId,
            Content = "" // Invalid content
        };

        var existingComment = new Comment
        {
            Id = commentId,
            Content = "Old content"
        };

        _mockCommentRepository.Setup(r => r.GetByIdAsync(commentId)).ReturnsAsync(existingComment);

        var command = new UpdateCommentCommand(input);

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(CommentErrors.NoContent, result.Error);
    }
}