using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Input;

namespace Blog.Core.Infrastructure.Mapper
{
    public class AddArticleInputMapper : ITypeConverter<AddArticleInput, Article>
    {
        public Article Convert(AddArticleInput source, Article destination, ResolutionContext context)
        {
            destination = new Article()
            {
                Title = source.Title,
                Type = source.Type,
                Value = source.Content,
                Categories = string.Join(',', source.Categories)
            };
            return destination;
        }
    }
}
