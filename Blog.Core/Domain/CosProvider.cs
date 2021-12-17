using System;
using System.Collections.Generic;
using System.Linq;
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

        public StsClientCredentialConfig GenerateConfig()
        {
            return new StsClientCredentialConfig()
            {
                SecretId = Account.SecretId,
                SecretKey = Account.SecretKey,
                DurationSeconds = Duration,
                Bucket = $"{BucketName}-{Account.AppId}",
                Region = Region,
                AllowPrefixes = AllowPrefix.Split(','),
                AllowActions = GetAllowActions(),
            };
        }

        private string[] GetAllowActions()
        {
            var actions = new List<string>();
            var types = AllowActions.Split(',').Select(Enum.Parse<TencentStsAction>);
            foreach (var type in types)
            {
                actions.AddRange(GetActionsByType(type));
            }

            return actions.ToArray();
        }

        private IList<string> GetActionsByType(TencentStsAction type)
        {
            var result = new List<string>();
            switch (type)
            {
                case TencentStsAction.NormalUpload:
                    result.AddRange(new [] { "name/cos:PutObject" });
                    break;
                case TencentStsAction.FormOrMiniUpload:
                    result.AddRange(new [] { "name/cos:PostObject" });
                    break;
                case TencentStsAction.MultipartUpload:
                    result.AddRange(new[]
                    {
                        "name/cos:InitiateMultipartUpload",
                        "name/cos:ListMultipartUploads",
                        "name/cos:ListParts",
                        "name/cos:UploadPart",
                        "name/cos:CompleteMultipartUpload"
                    });
                    break;
            }

            return result;
        }
    }
}