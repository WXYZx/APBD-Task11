namespace Tutorial11.Exeptions;

public class BadReqException : Exception
{
    public BadReqException() : base()
    {
    }
    
    public BadReqException(string? message) : base(message)
    {
    }
}