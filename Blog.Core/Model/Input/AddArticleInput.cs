using Blog.Core.Domain;

namespace Blog.Core.Model.Input
{
    public class AddArticleInput
    {
        public string Title { get; set; }
        public ContentFormat Format { get; set; }
        public string Content { get; set; }
    }
}