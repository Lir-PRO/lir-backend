using Modules.Posts.Endpoints.GraphQL.Queries;

namespace Lir.Api.GraphQL.Query;

public class Query
{
    public PostQuery Post { get; set; }
    public CategoryQuery Category { get; set; }
    public CommentQuery Comment { get; set; }

    public Query(PostQuery post, 
        CategoryQuery category,
        CommentQuery comment)
    {
        Post = post;
        Category = category;
        Comment = comment;
    }
}