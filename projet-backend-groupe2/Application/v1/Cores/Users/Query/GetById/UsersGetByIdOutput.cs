namespace Application.v1.Cores.Users.Query.GetById;

public class UsersGetByIdOutput
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}