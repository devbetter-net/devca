namespace Dev.Core.Exceptions;

public class DevNotFoundException : Exception
{
    public DevNotFoundException(string name, object key)
        : base($"{name} ({key}) is not found")
    {
    }
}