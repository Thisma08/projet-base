namespace Domain.exceptions.user;

public class InvalidUsernameLengthException : System.Exception
{
    public InvalidUsernameLengthException() : base("Username must be between 3 and 50 characters.")
    {
    }
}