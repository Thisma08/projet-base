namespace Application.v1.Features.Scores.Queries.GetByQuizzId;

public class ScoreGetByQuizzIdOutput
{
    public List<Score> Scores { get; set; } = new();

    public class Score
    {
        public int Id { get; set; }
        public int ScoreValue { get; set; }
        public int QuizzId { get; set; }
    }
}