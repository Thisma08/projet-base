namespace Domain.exceptions;

public class NotGoodLoginException : System.Exception
{
    public NotGoodLoginException() : base("Login or password are invalid")
    {
    }

    public NotGoodLoginException(string msg) : base(msg)
    {
    }
}