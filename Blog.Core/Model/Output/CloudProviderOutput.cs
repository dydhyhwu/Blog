using System;
using System.Collections.Generic;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output
{
    public class CloudProviderOutput
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Region { get; set; }
        public string BucketName { get; set; }
        public int Duration { get; set; }
        public string AllowPrefix { get; set; }
        public IList<TencentStsAction> AllowActions { get; set; }
        public bool Enable { get; set; }
    }
}