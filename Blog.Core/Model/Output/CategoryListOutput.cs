using System;

namespace Blog.Core.Model.Output
{
    public class CategoryListOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
    }
}