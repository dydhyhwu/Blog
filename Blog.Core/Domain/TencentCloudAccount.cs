using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZeroSum.Attributes;

namespace Blog.Core.Domain
{
    [Entity]
    [Table(nameof(TencentCloudAccount))]
    [Description("腾讯云账号")]
    public class TencentCloudAccount : BaseEntity
    {
        [MaxLength(32)]
        public string AppId { get; set; }
        
        [MaxLength(128)]
        public string SecretId { get; set; }
        
        [MaxLength(128)]
        public string SecretKey { get; set; }
        
        [MaxLength(255)]
        public string Name { get; set; }
    }
}