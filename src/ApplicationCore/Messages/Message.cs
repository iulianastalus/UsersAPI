namespace Users.ApplicationCore.Messages;

public class Message
{
    private readonly string _successMessage;
    public Message(string successMessage)
    {
        _successMessage = successMessage;
    }
}
