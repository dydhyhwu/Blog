using System;

namespace Blog.Core.Model.Input
{
    public class ArticleEditInput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Categories { get; set; }
    }
}