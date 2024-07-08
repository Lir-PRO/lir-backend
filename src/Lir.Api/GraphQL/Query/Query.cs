using Modules.Posts.Endpoints.GraphQL.Queries;
using Modules.Users.Endpoints.GraphQL.Queries;

namespace Lir.Api.GraphQL.Query;

public class Query
{
    public PostQuery Post { get; set; }
    public CategoryQuery Category { get; set; }
    public CommentQuery Comment { get; set; }
    public UserQuery User { get; set; }

    public Query(PostQuery post, 
        CategoryQuery category,
        CommentQuery comment, 
        UserQuery user)
    {
        Post = post;
        Category = category;
        Comment = comment;
        User = user;
    }
}