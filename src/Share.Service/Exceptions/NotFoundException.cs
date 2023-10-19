namespace Share.Service.Exceptions;

public class NotFoundException:Exception
{
    public NotFoundException(string message):base(message)
    {
        StatusCode = 404;
    }

    public int StatusCode { get; set; }
}