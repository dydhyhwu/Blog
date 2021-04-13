namespace Blog.Core.Domain
{
    public interface Authorized
    {
        public bool NeedAuthorized { get; set; }
        public string AuthorizeCode { get; set; }
    }
}