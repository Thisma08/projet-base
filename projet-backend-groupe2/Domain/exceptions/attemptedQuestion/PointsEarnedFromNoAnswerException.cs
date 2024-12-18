namespace Domain.exceptions.attemptedQuestion;

public class PointsEarnedFromNoAnswerException : System.Exception
{
    public PointsEarnedFromNoAnswerException() : base("The user earned points even though they didn't answer.")
    {
        
    }
}