namespace Blog.Core.Domain
{
    /// <summary>
    /// 用于需要加锁的内容
    /// </summary>
    public interface INeedAuthorize
    {
        /// <summary>
        /// 是否开启验证
        /// </summary>
        public bool NeedAuthorized { get; set; }
        
        /// <summary>
        /// 授权码（加密码）
        /// </summary>
        public string AuthorizeCode { get; set; }
    }
}