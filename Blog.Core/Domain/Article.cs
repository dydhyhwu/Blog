using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZeroSum.Attributes;

namespace Blog.Core.Domain
{
    [Entity]
    [Table(nameof(Article))]
    [Description("博客文章")]
    public class Article : BaseEntity, INeedAuthorize
    {
        [MaxLength(255)]
        public string Title { get; set; }
        public string Value { get; set; }
        public ContentType Type { get; set; }
        
        [MaxLength(255)]
        public string Categories { get; set; }

        public static Article Of(Guid id)
        {
            return new Article()
            {
                Id = id
            };
        }

        public bool NeedAuthorized { get; set; }
        
        [MaxLength(32)]
        public string AuthorizeCode { get; set; }
    }
}
