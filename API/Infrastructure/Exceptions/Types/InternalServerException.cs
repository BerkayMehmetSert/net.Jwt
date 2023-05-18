namespace API.Infrastructure.Exceptions.Types;

public class InternalServerException : Exception
{
    public InternalServerException(string message) : base(message)
    {
    }
}