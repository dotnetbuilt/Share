namespace Share.Service.Exceptions;

public class AlreadyExistsException:Exception
{
    public AlreadyExistsException(string message):base(message)
    {
        StatusCode = 403;
    }

    public int StatusCode { get;set; }
}