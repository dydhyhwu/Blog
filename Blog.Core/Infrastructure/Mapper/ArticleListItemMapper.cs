using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Output;

namespace Blog.Core.Infrastructure.Mapper
{
    public class ArticleListItemMapper : ITypeConverter<Article, ArticleListItemOutput>
    {
        public ArticleListItemOutput Convert(Article source, ArticleListItemOutput destination, ResolutionContext context)
        {
            destination = new ArticleListItemOutput()
            {
                Id = source.Id,
                Title = source.Title,
                CreateTime = source.CreateTime
            };
            return destination;
        }
    }
}
