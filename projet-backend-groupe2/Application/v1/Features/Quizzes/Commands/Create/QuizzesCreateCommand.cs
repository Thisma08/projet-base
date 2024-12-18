namespace Application.v1.Features.Quizzes.Commands.Create;

public class QuizzesCreateCommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Themes Theme { get; set; }
    public List<Question> Questions { get; set; } = new();
    public Users User { get; set; }

    public class Themes
    {
        public int Id { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }
    }

    public class Question
    {
        public string QuestionText { get; set; }
        public string CorrectChoice { get; set; }
        public string IncorrectChoice1 { get; set; }
        public string IncorrectChoice2 { get; set; }
        public string IncorrectChoice3 { get; set; }
    }
}