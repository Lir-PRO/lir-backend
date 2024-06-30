namespace Modules.Users.Application.Common.Models;

public class AddUserInput
{
    public string Username { get; set;}
    public string? Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Bio { get; set; }
    public string? ProfilePictureBase64 { get; set; }
}