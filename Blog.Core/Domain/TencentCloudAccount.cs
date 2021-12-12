using YH.Arch.Domain;

namespace Blog.Core.Domain
{
    public class TencentCloudAccount : BaseEntity
    {
        public string AppId { get; set; }
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
        public string Name { get; set; }
    }
}