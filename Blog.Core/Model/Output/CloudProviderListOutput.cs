using System;

namespace Blog.Core.Model.Output
{
    public class CloudProviderListOutput
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Region { get; set; }
        public string BucketName { get; set; }
        public int Duration { get; set; }
        public string AllowPrefix { get; set; }
    }
}