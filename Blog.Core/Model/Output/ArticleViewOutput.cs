using System;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output
{
    public class ArticleViewOutput
    {
        public Guid Id { get; set; }
        public ContentFormat Format { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}