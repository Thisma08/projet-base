namespace Application.v1.Features.Scores.Commands.Create;

public class ScoreCreateOutput
{
    public int Id { get; set; }
    public int ScoreValue { get; set; }
    public int UserId { get; set; }
    public int QuizzId { get; set; }
}