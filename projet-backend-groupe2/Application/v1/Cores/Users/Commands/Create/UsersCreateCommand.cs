using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Domain;
using Domain.models;

namespace Application.v1.Cores.Users.Commands.Create;

public class UsersCreateCommand
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 150 characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(150, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Role is required.")]
    [StringSyntax(User.PatternRoles)]
    public string Role { get; set; }
}