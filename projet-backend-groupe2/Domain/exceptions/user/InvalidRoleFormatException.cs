namespace Domain.exceptions.user;

public class InvalidRoleFormatException: System.Exception
{
    public InvalidRoleFormatException() : base("The format of the role is invalid.")
    {
    }
}