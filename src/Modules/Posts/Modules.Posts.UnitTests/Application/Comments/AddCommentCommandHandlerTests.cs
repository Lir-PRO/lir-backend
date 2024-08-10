using AutoMapper;
using Modules.Posts.Application.Comments.Commands.AddComment;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;
using Moq;

namespace Modules.Posts.UnitTests.Application.Comments;

[TestFixture]
public class AddCommentCommandHandlerTests
{
    private Mock<ICommentRepository> _mockCommentRepository;
    private Mock<IMapper> _mockMapper;
    private AddCommentCommandHandler _sut;

    [SetUp]
    public void SetUp()
    {
        _mockCommentRepository = new Mock<ICommentRepository>();
        _mockMapper = new Mock<IMapper>();

        _sut = new AddCommentCommandHandler(_mockCommentRepository.Object, _mockMapper.Object);
    }

    [Test]
    public async Task Handle_ShouldAddCommentAndReturnPayload_WhenInputIsValid()
    {
        // Arrange
        var input = new AddCommentInput
        {
            UserId = "user123",
            PostId = Guid.NewGuid(),
            Content = "This is a comment"
        };

        var comment = new Comment
        {
            UserId = input.UserId,
            PostId = input.PostId,
            Content = input.Content
        };

        var commentPayload = new CommentPayload
        {
            Id = comment.Id,
            UserId = comment.UserId,
            PostId = comment.PostId,
            Content = comment.Content
        };

        _mockMapper.Setup(m => m.Map<CommentPayload>(It.IsAny<Comment>())).Returns(commentPayload);

        // Act
        var result = await _sut.Handle(new AddCommentCommand(input), CancellationToken.None);

        // Assert
        _mockCommentRepository.Verify(cr => cr.AddAsync(It.IsAny<Comment>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.AreEqual(commentPayload, result.Data);
    }

    [Test]
    public void Handle_ShouldThrowArgumentNullException_WhenInputIsNull()
    {
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Handle(null, CancellationToken.None));
    }

    [Test]
    public void Handle_ShouldThrowArgumentException_WhenContentIsEmpty()
    {
        // Arrange
        var input = new AddCommentInput
        {
            UserId = "user123",
            PostId = Guid.NewGuid(),
            Content = "" // Empty content
        };

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(() => _sut.Handle(new AddCommentCommand(input), CancellationToken.None));
    }
}