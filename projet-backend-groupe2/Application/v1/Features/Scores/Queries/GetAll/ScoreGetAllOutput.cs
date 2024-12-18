namespace Application.v1.Features.Scores.Queries.GetAll;

public class ScoreGetAllOutput
{
    public List<Score> Scores { get; set; } = new();

    public class Score
    {
        public int Id { get; set; }
        public int ScoreValue { get; set; }
        public int UserId { get; set; }
        public int QuizzId { get; set; }
    }
}