using YH.Arch.Domain;

namespace Blog.Core.Domain
{
    public class Content : BaseEntity
    {
        public string Value { get; set; }
    }

    public class UrlContent : Content
    {

    }
}
