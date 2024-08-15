using Modules.Posts.Endpoints.GraphQL.Mutations;
using Modules.Users.Endpoints.GraphQL.Mutations;
using Modules.Chats.Endpoints.GraphQL.Mutations;

namespace Lir.Api.GraphQL.Mutation;

public class Mutation
{
    public PostMutation Post { get; set; }
    public MessageMutation Message { get; set; }
    public ChatMutation Chat { get; set; }
    public CategoryMutation Category { get; set; }
    public CommentMutation Comment { get; set; }
    public UserMutation User { get; set; }
    public SubscriptionMutation Subscription { get; set; }

    public Mutation(PostMutation post, 
        UserMutation user,
        CategoryMutation category, 
        CommentMutation comment, 
        SubscriptionMutation subscription, ChatMutation chat, MessageMutation message)
    {
        Post = post;
        User = user;
        Category = category;
        Comment = comment;
        Subscription = subscription;
        Chat = chat;
        Message = message;
    }
}