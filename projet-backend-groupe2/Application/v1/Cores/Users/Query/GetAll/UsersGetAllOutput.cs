namespace Application.v1.Cores.Users.Query.GetAll;

public class UsersGetAllOutput
{
    public List<User> Users { get; set; } = new();

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}