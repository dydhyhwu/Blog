using System;

namespace Blog.Core.Model.Output
{
    public class ArticleListItemOutput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
    }
}