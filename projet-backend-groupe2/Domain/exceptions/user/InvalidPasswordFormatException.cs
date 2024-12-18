namespace Domain.exceptions.user;

public class InvalidPasswordFormatException: System.Exception
{
    public InvalidPasswordFormatException() : base("The format of the password is invalid.")
    {
    }
    
}