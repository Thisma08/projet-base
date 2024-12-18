namespace Application.v1.Features.Questions.Commands.Create;

public class QuestionCreateOutput
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public string CorrectChoice { get; set; }
    public string IncorrectChoice1 { get; set; }
    public string IncorrectChoice2 { get; set; }
    public string IncorrectChoice3 { get; set; }
    public int QuizzId { get; set; }
}