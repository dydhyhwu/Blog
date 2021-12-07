using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Output;

namespace Blog.Core.Infrastructure.Mapper
{
    public class CategoryListOutputMapper : ITypeConverter<Category, CategoryListOutput>
    {
        public CategoryListOutput Convert(Category source, CategoryListOutput destination, ResolutionContext context)
        {
            destination = new CategoryListOutput()
            {
                Id = source.Id,
                Name = source.Name,
                CreateTime = source.CreateTime
            };
            return destination;
        }
    }
}