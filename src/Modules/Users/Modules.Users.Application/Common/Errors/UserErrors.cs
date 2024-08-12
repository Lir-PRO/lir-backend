using Common;

namespace Modules.Users.Application.Common.Errors;

public static class UserErrors
{
    public static readonly Error UsernameIsTaken = new(
        "Users.UsernameIsTaken",
        "User with this username already exists");

    public static readonly Error EmailIsAlreadyUsed = new(
        "Users.EmailIsAlreadyUsed",
        "This email is already used by another account");

    public static readonly Error AddUserFailure = new(
        "Users.AddUserFailure",
        "Failed to add the user");

    public static readonly Error UpdateUserFailure = new(
        "Users.UpdateUserFailure",
        "Failed to update the user");

    public static readonly Error InputIsNull = new(
        "Users.InputIsNull",
        "Input can not be null");

    public static readonly Error NotFound = new(
        "Users.NotFound",
        "User not found");

    public static readonly Error DeleteUserFailureAuth0 = new(
        "Users.DeleteUserFailureAuth0",
        "Failed to delete user from Auth0");

    public static readonly Error DeleteUserFailure = new(
        "Users.DeleteUserFailure",
        "Failed to delete user");

}