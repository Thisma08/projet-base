namespace Domain.exceptions;

public class NotFoundObjectException : System.Exception
{
    public NotFoundObjectException(int id, string className)
        : base($"Object of class '{className}' with ID '{id}' was not found.")
    {
    }

    public NotFoundObjectException(string name, string className)
        : base($"Object of class '{className}' with name '{name}' was not found.")
    {
    }
}