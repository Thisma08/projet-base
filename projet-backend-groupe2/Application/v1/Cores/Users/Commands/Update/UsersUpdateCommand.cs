using System.ComponentModel.DataAnnotations;

namespace Application.v1.Cores.Users.Commands.Update;

public class UsersUpdateCommand
{
    private string _password;
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 150 characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(150, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
    public string Password
    {
        get => _password;
        set => _password = BCrypt.Net.BCrypt.EnhancedHashPassword(value, 13);
    }

    [Required(ErrorMessage = "Role is required.")]
    [StringLength(50, ErrorMessage = "Role must be a maximum of 50 characters.")]
    public string Role { get; set; }
}