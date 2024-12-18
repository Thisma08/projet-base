using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF.DbEntities;

public class DbQuestion
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public string CorrectChoice { get; set; }
    public string IncorrectChoice1 { get; set; }
    public string IncorrectChoice2 { get; set; }
    public string IncorrectChoice3 { get; set; }
    public int QuizzId { get; set; }

    [ForeignKey("QuizzId")] public virtual DbQuizz Quizz { get; set; }
}