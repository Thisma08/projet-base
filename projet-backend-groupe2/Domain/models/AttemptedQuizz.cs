namespace Domain.models;

public class AttemptedQuizz
{
    public int Score { get; set; }
    public List<AttemptedQuestion> AttemptedQuestions { get; set; }

    public AttemptedQuizz(List<AttemptedQuestion> attemptedQuestions)
    {
        AttemptedQuestions = attemptedQuestions;
        CalculateScore();
    }

    public AttemptedQuizz(AttemptedQuizz attemptedQuizz)
    {
        AttemptedQuestions = new List<AttemptedQuestion>();
        attemptedQuizz.AttemptedQuestions.ForEach(q => AttemptedQuestions.Add(new AttemptedQuestion(q)));
        Score = attemptedQuizz.Score;
    }

    private int CalculateScore()
    {
        Score = AttemptedQuestions.Sum(q => q.Score) ?? 0;
        return Score;
    }
}