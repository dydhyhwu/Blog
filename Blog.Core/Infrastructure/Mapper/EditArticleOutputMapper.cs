using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Output;

namespace Blog.Core.Infrastructure.Mapper
{
    public class EditArticleOutputMapper : ITypeConverter<Article, ArticleEditOutput>
    {
        public ArticleEditOutput Convert(Article source, ArticleEditOutput destination, ResolutionContext context)
        {
            destination = new ArticleEditOutput()
            {
                Id = source.Id,
                Title = source.Title,
                Content = source.Value
            };
            return destination;
        }
    }
}
