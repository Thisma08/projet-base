namespace Domain.models;

public class Quizz
{
    
    private string Title { get; set; }
    private string Description { get; set; }
    private string Theme { get; set; }
    private User User { get; set; }
    private List<Question> Questions { get; set; }
    
    public Quizz(string title, string description, string theme, User user, List<Question> questions)
    {
        if (title.Length is < 3 or > 50)
            throw new System.Exception("Not a valid title");
        if (description.Length is < 3 or > 500)
            throw new System.Exception("Not a valid description");
        if (theme.Length is < 3 or > 50)
            throw new System.Exception("Not a valid theme");
        if (questions.Count > 1)
            throw new System.Exception("Not more than one question");
        
        Title = title;
        Description = description;
        Theme = theme;
        User = user;
        Questions = questions;
    }

}