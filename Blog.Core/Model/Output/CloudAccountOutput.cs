using System;

namespace Blog.Core.Model.Output
{
    public class CloudAccountOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AppId { get; set; }
        public string SecrectId { get; set; }
        public string SecrectKey { get; set; }
    }
}