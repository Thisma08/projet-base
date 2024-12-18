using System.Text.RegularExpressions;
using Domain.exceptions.user;
using Crypt = BCrypt.Net.BCrypt;

namespace Domain.models;

public class User
{
    private string Username { get; set; }
    private string? Email { get; set; }
    private string HashedPassword { get; set; }
    private string? Role { get; set; }

    private const string PatternPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
    private const string PatternMail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    public const string PatternRoles = @"^(ROLES_ADMIN|ROLES_USER)$";

    public User(string username, string hashedPassword, string? email = null, string? role = null)
    {
        Username = username;
        Email = email;
        HashedPassword = hashedPassword;
        Role = role;
    }

    public static User Register(string username, string password, string email, string? role = "ROLES_USER")
    {
        //TODO : Créer des classes d'exception

        // Check that encoded data is correct
        if (username.Length is < 3 or > 50)
            throw new InvalidUsernameLengthException();
        if (!Regex.IsMatch(password, PatternPassword))
            throw new InvalidPasswordFormatException();
        if (!Regex.IsMatch(email, PatternMail))
            throw new InvalidEmailFormatException();
        if (!Regex.IsMatch(role!, PatternRoles))
            throw new InvalidRoleFormatException();

        password = Crypt.HashPassword(password);
        var user = new User(username, password, email, role);

        return user;
    }

    public bool Login(string password)
    {
        return Crypt.Verify(password, HashedPassword);
    }

    public string GetUsername()
    {
        return this.Username;
    }

    public string? GetEmail()
    {
        return this.Email;
    }

    public string GetHashedPassword()
    {
        return this.HashedPassword;
    }

    public string? GetRole()
    {
        return this.Role;
    }
}