namespace Infrastructure.EF.DbEntities;

public class DbTheme
{
    public int Id { get; set; }

    public string Title { get; set; }

    // Navigation property
    public virtual ICollection<DbQuizz> Quizzes { get; set; } = new List<DbQuizz>();
}