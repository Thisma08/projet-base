namespace Application.v1.Cores.Users.Commands.Create;

public class UsersCreateOutput
{
    public int Id { get; set; }
    public string Username { get; set; }

    public string Email { get; set; }

    // public string Password { get; set; }
    public string Role { get; set; }
}