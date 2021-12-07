using System;

namespace Blog.Core.Domain
{
    public class Article : Content
    {
        public ContentFormat Format { get; set; }

        public string Categories { get; set; }

        public static Article Of(Guid id)
        {
            return new Article()
            {
                Id = id
            };
        }
    }
}
