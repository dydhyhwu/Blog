using System;
using YH.Arch.Domain;

namespace Blog.Core.Domain
{
    /// <summary>
    /// 分类（关联类别和文章）
    /// </summary>
    public class Classify : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid ArticleId { get; set; }
    }
}