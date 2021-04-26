using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Output;

namespace Blog.Core.Infrastructure.Mapper
{
    public class ArticleViewOutputMapper : ITypeConverter<Article, ArticleViewOutput>
    {
        public ArticleViewOutput Convert(Article source, ArticleViewOutput destination, ResolutionContext context)
        {
            destination = new ArticleViewOutput()
            {
                Id = source.Id,
                Format = source.Format,
                Title = source.Title,
                Content = source.Value,
                CreateTime = source.CreateTime,
            };
            return destination;
        }
    }
}
