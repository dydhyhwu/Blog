namespace Blog.Core.Model.Output
{
    public class CosProviderConfigOutput
    {
        public string Bucket { get; set; }
        public string Region { get; set; }
        public string UploadPrefix { get; set; }
        public string Host { get; set; }
    }
}