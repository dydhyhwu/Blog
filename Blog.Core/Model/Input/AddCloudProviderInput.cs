using System;
using System.Collections.Generic;
using Blog.Core.Domain;

namespace Blog.Core.Model.Input
{
    public class AddCloudProviderInput
    {
        public string Region { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string AllowPrefix { get; set; }
        public IList<TencentStsAction> AllowActions { get; set; }
        public Guid AccountId { get; set; }
    }
}