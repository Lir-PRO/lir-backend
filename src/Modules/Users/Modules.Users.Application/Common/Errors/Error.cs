namespace Modules.Users.Application.Common.Errors;

public class Error
{
    public Error(string code, string? description = null)
    {
        Code = code;
        Description = description;
    }
    public string Code { get; set; }
    public string? Description { get; set; } = null;
    public static readonly Error None = new(string.Empty, string.Empty);
}