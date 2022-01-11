using System;
using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output
{
    [AutoMap(typeof(TencentCloudAccount))]
    public class CloudAccountListOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AppId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}