using System;

namespace Blog.Core.Model.Output
{
    public class CloudAccountListOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AppId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}