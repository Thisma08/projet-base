namespace Infrastructure.EF.DbEntities;

public class DbScore
{
    public int Id { get; set; }
    public int ScoreValue { get; set; }
    public int UserId { get; set; }
    public int QuizzId { get; set; }
}