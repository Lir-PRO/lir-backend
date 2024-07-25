using AutoMapper;
using Modules.Posts.Application.Comments.Commands.UpdateComment;
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
        _mockMapper.Setup(m => m.Map<CommentPayload>(It.IsAny<Comment>())).Returns(updatedCommentPayload);

        // Act
        var result = await _sut.Handle(new UpdateCommentCommand(input), CancellationToken.None);

        // Assert
        _mockCommentRepository.Verify(r => r.UpdateAsync(commentId, existingComment, It.IsAny<CancellationToken>()), Times.Once);
        Assert.AreEqual(updatedCommentPayload, result);
    }

    [Test]
    public void Handle_ShouldThrowArgumentNullException_WhenInputIsNull()
    {
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Handle(null, CancellationToken.None));
    }

    [Test]
    public void Handle_ShouldThrowArgumentException_WhenCommentIdIsInvalid()
    {
        // Arrange
        var input = new UpdateCommentInput
        {
            CommentId = Guid.Empty, // Invalid CommentId
            Content = "Updated content"
        };

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(() => _sut.Handle(new UpdateCommentCommand(input), CancellationToken.None));
    }

    [Test]
    public void Handle_ShouldThrowInvalidOperationException_WhenCommentDoesNotExist()
    {
        // Arrange
        var commentId = Guid.NewGuid();
        var input = new UpdateCommentInput
        {
            CommentId = commentId,
            Content = "Updated content"
        };

        _mockCommentRepository.Setup(r => r.GetByIdAsync(commentId)).ReturnsAsync((Comment)null);

        // Act & Assert
        Assert.ThrowsAsync<InvalidOperationException>(() => _sut.Handle(new UpdateCommentCommand(input), CancellationToken.None));
    }
}