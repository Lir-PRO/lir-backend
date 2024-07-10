using System.ComponentModel.DataAnnotations;

namespace Modules.Users.Application.Common.Input;

public class UpdateUserInput
{
    public string Id { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }
    public string? Name { get; set; }
    public string? Bio { get; set; }
    public string? ProfilePictureBase64 { get; set; }
}