using YH.Arch.Domain;

namespace Blog.Core.Domain
{
    public class Content : BaseEntity, Authorized
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public bool NeedAuthorized { get; set; }
        public string AuthorizeCode { get; set; }
    }
}
