using System;

namespace Blog.Core.Model.Input
{
    public class EditCloudAccountInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AppId { get; set; }
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
    }
}