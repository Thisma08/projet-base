namespace Application.v1.Features.Scores.Queries.GetById;

public class ScoreGetByIdOutput
{
    public int Id { get; set; }
    public int ScoreValue { get; set; }
    public int UserId { get; set; }
    public int QuizzId { get; set; }
}