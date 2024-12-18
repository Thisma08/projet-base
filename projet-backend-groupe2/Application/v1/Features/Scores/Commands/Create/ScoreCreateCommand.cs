namespace Application.v1.Features.Scores.Commands.Create;

public class ScoreCreateCommand
{
    public int ScoreValue { get; set; }
    public int UserId { get; set; }
    public int QuizzId { get; set; }
}