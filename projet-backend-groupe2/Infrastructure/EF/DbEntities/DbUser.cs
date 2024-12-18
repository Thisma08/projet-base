namespace Infrastructure.EF.DbEntities;

public class DbUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    // Navigation property
    public virtual ICollection<DbQuizz> Quizzes { get; set; } = new HashSet<DbQuizz>();
}