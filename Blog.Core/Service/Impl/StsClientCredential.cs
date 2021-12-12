namespace Blog.Core.Service.Impl
{
    public class StsClientCredential
    {
        public TempCredential Credentials { get; set; }
        public int ExpiredTime { get; set; }
        public string Expiration { get; set; }
        public string RequestId { get; set; }
        public int StartTime { get; set; }
    }
}