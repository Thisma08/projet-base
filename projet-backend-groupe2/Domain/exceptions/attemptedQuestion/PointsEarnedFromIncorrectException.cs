namespace Domain.exceptions.attemptedQuestion;

public class PointsEarnedFromIncorrectException : System.Exception
{
    public PointsEarnedFromIncorrectException() : base("The user earned points from an incorrect answer.")
    {
        
    }
    
}