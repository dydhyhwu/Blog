using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Input
{
    [AutoMap(typeof(Category), ReverseMap = true)]
    public class AddCategoryInput
    {
        public string Name { get; set; }
    }
}