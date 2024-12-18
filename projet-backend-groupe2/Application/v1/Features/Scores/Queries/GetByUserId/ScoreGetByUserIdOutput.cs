namespace Application.v1.Features.Scores.Queries.GetByUserId;

public class ScoreGetByUserIdOutput
{
    public List<Score> Scores { get; set; } = new();

    public class Score
    {
        public int Id { get; set; }
        public int ScoreValue { get; set; }
        public int QuizzId { get; set; }
    }
}