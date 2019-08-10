namespace WebUI.Model
{
    public class MessageToClient
    {
        public string Message { get; set; }

        public MessageToClient(string msg)
        {
            Message = msg;
        }
    }
}
