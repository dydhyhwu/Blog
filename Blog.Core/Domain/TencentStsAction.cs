using System.ComponentModel;

namespace Blog.Core.Domain
{
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