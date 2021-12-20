namespace Blog.Core.Model.Output
{
    public class TempCredentialOutput
    {
        public string Token { get; set; }
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
        public int StartTime { get; set; }
        public int ExpiredTime { get; set; }
    }
}