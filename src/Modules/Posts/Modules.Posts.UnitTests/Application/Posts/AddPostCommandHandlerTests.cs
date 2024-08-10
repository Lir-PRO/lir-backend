using AutoMapper;
using Modules.Posts.Application.Common.Errors;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Application.Posts.Commands.AddPost;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Enums;
using Modules.Posts.Domain.Interfaces;
using Moq;

namespace Modules.Posts.UnitTests.Application.Posts;

[TestFixture]
public class AddPostCommandHandlerTests
{
    private Mock<IPostRepository> _mockPostRepository;
    private Mock<IContentRepository> _mockContentRepository;
    private Mock<IPostCategoryRepository> _mockPostCategoryRepository;
    private Mock<IMapper> _mockMapper;
    private AddPostCommandHandler _sut;

    [SetUp]
    public void SetUp()
    {
        _mockPostRepository = new Mock<IPostRepository>();
        _mockContentRepository = new Mock<IContentRepository>();
        _mockPostCategoryRepository = new Mock<IPostCategoryRepository>();
        _mockMapper = new Mock<IMapper>();

        _sut = new AddPostCommandHandler(
            _mockPostCategoryRepository.Object,
            _mockContentRepository.Object,
            _mockPostRepository.Object,
            _mockMapper.Object
        );
    }

    [Test]
    public async Task Handle_ShouldAddPostAndReturnPayload_WhenInputIsValid()
    {
        // Arrange
        var input = new AddPostInput
        {
            UserId = "user123",
            Caption = "Test Caption",
            CategoryIds = new List<Guid> { Guid.NewGuid() },
            ContentInputs = new List<ContentInput>
            {
                new ContentInput { ContentBase64 = "base64string", ContentType = ContentType.Video}
            }
        };

        var command = new AddPostCommand(input);
        var postPayload = new PostPayload { Id = Guid.NewGuid(), UserId = "user123", Caption = "Test Caption" };

        _mockMapper.Setup(m => m.Map<PostPayload>(It.IsAny<Post>())).Returns(postPayload);

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(postPayload, result.Data);

        _mockPostRepository.Verify(pr => pr.AddAsync(It.IsAny<Post>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockPostRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Guid>(), It.IsAny<Post>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockPostCategoryRepository.Verify(pc => pc.AddAsync(It.IsAny<PostCategory>()), Times.Once);
        _mockContentRepository.Verify(cr => cr.AddAsync(It.IsAny<Content>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task Handle_ShouldReturnFailureResponse_WhenUserIdIsMissing()
    {
        // Arrange
        var input = new AddPostInput
        {
            UserId = null, // Missing UserId
            Caption = "Test Caption",
            CategoryIds = new List<Guid> { Guid.NewGuid() },
            ContentInputs = new List<ContentInput>
            {
                new ContentInput { ContentBase64 = "base64string", ContentType = ContentType.Image }
            }
        };

        var command = new AddPostCommand(input);

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(PostErrors.UserIdRequired, result.Error);
    }
}