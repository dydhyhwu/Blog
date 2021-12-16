using System.ComponentModel;
using YH.Arch.Domain;

namespace Blog.Core.Domain
{
    public class CosProvider : BaseEntity
    {
        /// <summary>
        /// 关联的账号
        /// </summary>
        public virtual TencentCloudAccount Account { get; set; }
        
        /// <summary>
        /// cos桶所在地区
        /// </summary>
        public string Region { get; set; }
        
        /// <summary>
        /// 桶名（不带appId的）
        /// </summary>
        public string BucketName { get; set; }
        
        /// <summary>
        /// 临时授权凭证的有效期
        /// </summary>
        public int Duration { get; set; }
        
        /// <summary>
        /// 临时授权凭证允许访问的前缀
        /// </summary>
        public string AllowPrefix { get; set; }
        
        /// <summary>
        /// 临时授权凭证允许的操作
        /// </summary>
        public string AllowActions { get; set; }

        /// <summary>
        /// 是否启用，只能有一个处于启用状态
        /// </summary>
        public bool Enable { get; set; } = false;

        public virtual void IsDisable()
        {
            Enable = false;
        }

        public void IsEnable()
        {
            Enable = true;
        }
    }

    /// <summary>
    /// 腾讯云STS授权用，指明权限
    /// </summary>
    public enum TencentStsAction : int
    {
        /// <summary>
        /// 包含以下权限：
        /// name/cos:PutObject
        /// </summary>
        [Description("简单上传")]
        NormalUpload = 0,
        
        /// <summary>
        /// 包含以下权限：
        /// name/cos:PostObject
        /// </summary>
        [Description("表单、小程序上传")]
        FormOrMiniUpload = 1,
        
        /// <summary>
        /// 包含以下权限：
        /// name/cos:InitiateMultipartUpload
        /// name/cos:ListMultipartUploads
        /// name/cos:ListParts
        /// name/cos:UploadPart
        /// name/cos:CompleteMultipartUpload
        /// </summary>
        [Description("分块上传")]
        MultipartUpload = 2
    }
}