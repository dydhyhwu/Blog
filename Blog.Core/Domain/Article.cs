using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain
{
    [Table(nameof(Article))]
    [Description("博客文章")]
    public class Article : Content
    {
        public ContentFormat Format { get; set; }

        public string Categories { get; set; }

        public static Article Of(Guid id)
        {
            return new Article()
            {
                Id = id
            };
        }
    }
}
