using System.Collections.Generic;
using Blog.Core.Domain;

namespace Blog.Core.Model.Input
{
    public class AddArticleInput
    {
        public string Title { get; set; }
        public ContentType Type { get; set; }
        public string Content { get; set; }
        public IList<string>  Categories { get; set; }
    }
}