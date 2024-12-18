namespace Domain.exceptions.attemptedQuestion;

public class QuestionNotContainingAnswerException : System.Exception
{
    public QuestionNotContainingAnswerException() : base("The question doesn't contain the answer.")
    {
        
    }
}