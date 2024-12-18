namespace Domain.exceptions.attemptedQuestion;

public class NegativeEarnedPointsException : System.Exception
{
    public NegativeEarnedPointsException() : base("The user has negative earned points.")
    {
    }
}