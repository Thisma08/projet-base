namespace Domain.exceptions.attemptedQuestion;

public class NoPointsEarnedFromCorrectException : System.Exception
{
    public NoPointsEarnedFromCorrectException() : base("The user didn't earn points from a correct answer.")
    {
        
    }
}