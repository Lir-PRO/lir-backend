using AutoMapper;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Application.Posts.Commands.UpdatePost;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Enums;
using Modules.Posts.Domain.Interfaces;
using Moq;

namespace Modules.Posts.UnitTests.Application.Posts;

[TestFixture]
public class UpdatePostCommandHandlerTests
{
    private Mock<IPostRepository> _mockPostRepository;
    private Mock<IContentRepository> _mockContentRepository;
    private Mock<IPostCategoryRepository> _mockPostCategoryRepository;
    private Mock<IMapper> _mockMapper;
    private UpdatePostCommandHandler _sut;

    [SetUp]
    public void SetUp()
    {
        _mockPostRepository = new Mock<IPostRepository>();
        _mockContentRepository = new Mock<IContentRepository>();
        _mockPostCategoryRepository = new Mock<IPostCategoryRepository>();
        _mockMapper = new Mock<IMapper>();

        _sut = new UpdatePostCommandHandler(
            _mockMapper.Object,
            _mockPostCategoryRepository.Object,
            _mockContentRepository.Object,
            _mockPostRepository.Object
        );
    }

    [Test]
    public async Task Handle_ShouldUpdatePostAndReturnPayload_WhenInputIsValid()
    {
        // Arrange
        var postId = Guid.NewGuid();
        var input = new UpdatePostInput
        {
            PostId = postId,
            Caption = "Updated Caption",
            CategoryIds = new List<Guid> { Guid.NewGuid() },
            ContentInputs = new List<ContentInput>
            {
                new ContentInput { ContentBase64 = "newbase64string", ContentType = ContentType.Image }
            }
        };

        var post = new Post
        {
            Id = postId,
            Caption = "Old Caption",
            PostCategories = new List<PostCategory> { new PostCategory { PostId = postId, CategoryId = Guid.NewGuid() } },
            Contents = new List<Content> { new Content { PostId = postId, Base64 = "oldbase64string", ContentType = ContentType.Image } }
        };

        var postPayload = new PostPayload { Id = postId, Caption = "Updated Caption" };

        _mockPostRepository.Setup(r => r.GetPostByIdAsync(postId)).ReturnsAsync(post);
        _mockMapper.Setup(m => m.Map<PostPayload>(post)).Returns(postPayload);

        // Act
        var result = await _sut.Handle(new UpdatePostCommand(input), CancellationToken.None);

        // Assert
        _mockPostRepository.Verify(r => r.UpdateAsync(postId, post, It.IsAny<CancellationToken>()), Times.Once);
        _mockPostCategoryRepository.Verify(pc => pc.AddAsync(It.IsAny<PostCategory>()), Times.Once);
        _mockContentRepository.Verify(cr => cr.AddAsync(It.IsAny<Content>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockContentRepository.Verify(cr => cr.DeleteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.AreEqual(postPayload, result);
    }

    [Test]
    public void Handle_ShouldThrowArgumentNullException_WhenInputIsNull()
    {
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Handle(null, CancellationToken.None));
    }

    [Test]
    public void Handle_ShouldThrowArgumentException_WhenPostIdIsInvalid()
    {
        // Arrange
        var input = new UpdatePostInput
        {
            PostId = Guid.Empty, // Invalid PostId
            Caption = "Updated Caption",
            CategoryIds = new List<Guid> { Guid.NewGuid() },
            ContentInputs = new List<ContentInput>
            {
                new ContentInput { ContentBase64 = "base64string", ContentType = ContentType.Image }
            }
        };

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Handle(new UpdatePostCommand(input), CancellationToken.None));
    }
}