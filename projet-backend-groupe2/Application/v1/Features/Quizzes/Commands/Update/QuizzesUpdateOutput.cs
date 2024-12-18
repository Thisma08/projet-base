namespace Application.v1.Features.Quizzes.Commands.Update;

public class QuizzesUpdateOutput
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Question> questions { get; set; }
    public Users user { get; set; }

    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string CorrectChoice { get; set; }
        public string IncorrectChoice1 { get; set; }
        public string IncorrectChoice2 { get; set; }
        public string IncorrectChoice3 { get; set; }
    }
}