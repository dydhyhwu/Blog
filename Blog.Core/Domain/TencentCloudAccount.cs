using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using YH.Arch.Domain;

namespace Blog.Core.Domain
{
    [Table(nameof(TencentCloudAccount))]
    [Description("腾讯云账号")]
    public class TencentCloudAccount : BaseEntity
    {
        public string AppId { get; set; }
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
        public string Name { get; set; }
    }
}