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
                Format = source.Format,
                Value = source.Content,
            };
            return destination;
        }
    }
}
