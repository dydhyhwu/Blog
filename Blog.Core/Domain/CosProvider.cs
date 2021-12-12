using YH.Arch.Domain;

namespace Blog.Core.Domain
{
    public class CosProvider : BaseEntity
    {
        public TencentCloudAccount Account { get; set; }
        public string Region { get; set; }
        public string BucketName { get; set; }
        public int Duration { get; set; }
        public string AllowPrefix { get; set; }
        public string AllowActions { get; set; }
    }
}