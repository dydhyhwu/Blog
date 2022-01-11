using System;
using Blog.Core.Domain;
using Blog.Core.Infrastructure.Orm;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using ZeroSum.DependencyInjection.Attributes;
using ZeroSum.Domain.Repositories;
using ZeroSum.Extend.Mapper.Extensions;

namespace Blog.Core.Service.Impl
{
    [Register]
    public class ArticleServiceImpl : ArticleService
    {
        private readonly IRepository repository;
        private readonly Queries queries;

        public ArticleServiceImpl(IRepository repository, Queries queries)
        {
            this.repository = repository;
            this.queries = queries;
        }

        public void Add(AddArticleInput input)
        {
            var article = input.MapTo<Article>();
            repository.Add(article);
        }

        public ArticleViewOutput Get(Guid id)
        {
            var article = repository.Get(queries.GetArticle(id));
            return article.MapTo<ArticleViewOutput>();
        }

        public PageList<ArticleListItemOutput> List(PageListInput input)
        {
            var count = repository.Count(queries.GetArticles());
            var articles = repository.GetList(queries.GetArticles().Paged(input.Index, input.Size));
            return new PageList<ArticleListItemOutput>()
            {
                Count = count,
                Index = input.Index,
                Size = input.Size,
                Data = articles.MapList<Article, ArticleListItemOutput>(),
            };
        }

        public ArticleEditOutput Detail(Guid id)
        {
            var article = repository.Get(queries.GetArticle(id));
            return article.MapTo<ArticleEditOutput>();
        }

        public void Edit(ArticleEditInput input)
        {
            var article = input.MapTo<Article>();
            repository.Update(article);
        }

        public void Delete(Guid id)
        {
            var article = Article.Of(id);
            repository.Remove(article);
        }
    }
}