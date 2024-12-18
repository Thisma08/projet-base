namespace Domain.exceptions.attemptedQuestion;

public class NegativeTimeException : System.Exception
{
    public NegativeTimeException() : base("Time cannot be less or equal than 0.")
    {
        
    }
}