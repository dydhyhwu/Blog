using System.Linq;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Input;

namespace Blog.Core.Infrastructure.Mapper
{
    public class ArticleEditInputMapper : ITypeConverter<ArticleEditInput, Article>
    {
        public Article Convert(ArticleEditInput source, Article destination, ResolutionContext context)
        {
            destination = new Article()
            {
                Id = source.Id,
                Title = source.Title,
                Value = source.Content,
                Categories = string.Join(',', source.Categories)
            };
            return destination;
        }
    }
}
