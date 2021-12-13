using System;
using System.Collections.Generic;
using Blog.Core.Domain;

namespace Blog.Core.Model.Input
{
    public class EditCloudProviderInput
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Region { get; set; }
        public string BucketName { get; set; }
        public int Duration { get; set; }
        public string AllowPrefix { get; set; }
        public IList<TencentStsAction> AllowActions { get; set; }
    }
}