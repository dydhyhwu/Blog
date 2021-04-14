namespace Blog.Core.Domain
{
    public interface Authorizeable
    {
        public bool NeedAuthorized { get; set; }
        public string AuthorizeCode { get; set; }
    }
}