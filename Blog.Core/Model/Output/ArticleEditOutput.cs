using System;
using System.Collections.Generic;

namespace Blog.Core.Model.Output
{
    public class ArticleEditOutput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IList<string> Categories { get; set; }
    }
}