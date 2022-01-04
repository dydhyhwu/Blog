namespace Blog.Core.Domain
{
    /// <summary>
    /// 用于需要加锁的内容
    /// </summary>
    public interface INeedAuthorize
    {
        public bool NeedAuthorized { get; set; }
        public string AuthorizeCode { get; set; }
    }
}