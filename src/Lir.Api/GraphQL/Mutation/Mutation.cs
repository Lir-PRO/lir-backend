using Modules.Posts.Endpoints.GraphQL.Mutations;
using Modules.Users.Endpoints.GraphQL.Mutations;

namespace Lir.Api.GraphQL.Mutation;

public class Mutation
{
    public PostMutation Post { get; set; }
    public UserMutation User { get; set; }

    public Mutation(PostMutation post, UserMutation user)
    {
        Post = post;
        User = user;
    }
}