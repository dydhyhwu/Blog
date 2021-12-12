namespace Blog.Core.Model.Input
{
    public class AddCloudAccountInput
    {
        public string Name { get; set; }
        public string AppId { get; set; }
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
    }
}