namespace RemoteConfig.Core.Exceptions;

public class UnprocessableRequestException : Exception
{
    public UnprocessableRequestException(string message) : base(message)
    {
    }
}