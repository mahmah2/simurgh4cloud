namespace WebUI.Model
{
    public class ContactRequest
    {
        public string FullName       { get; set; }
        public string EMail          { get; set; }
        public string Subject        { get; set; }
        public string Body           { get; set; }
        public string CaptchaRequest { get; set; }
        public override string ToString()
        {
            return $"[{FullName}],[{EMail}],[{Subject}],[{Body}]";
        }
    }
}
