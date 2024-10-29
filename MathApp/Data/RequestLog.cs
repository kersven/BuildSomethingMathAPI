namespace MathApp.Services
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string Endpoint { get; set; }
        public string RequestData { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
