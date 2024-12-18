namespace Domain.exceptions.user;

public class InvalidEmailFormatException: System.Exception
{
    public InvalidEmailFormatException() : base("The format of the email is invalid.")
    {
    }
}