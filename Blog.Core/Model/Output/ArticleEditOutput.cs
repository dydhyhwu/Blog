using System;

namespace Blog.Core.Model.Output
{
    public class ArticleEditOutput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}