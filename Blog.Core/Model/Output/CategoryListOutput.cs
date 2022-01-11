using System;
using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output
{
    [AutoMap(typeof(Category))]
    public class CategoryListOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
    }
}