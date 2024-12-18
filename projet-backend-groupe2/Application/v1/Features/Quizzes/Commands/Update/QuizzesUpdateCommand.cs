namespace Application.v1.Features.Quizzes.Commands.Update;

public class QuizzesUpdateCommand
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Themes Theme { get; set; }
    public Users User { get; set; }

    public class Themes
    {
        public int Id { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }
    }
}