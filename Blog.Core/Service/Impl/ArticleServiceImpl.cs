using System;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Infrastructure.Orm;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using YH.Arch.Infrastructure.Extension;
using ZeroSum.Domain.Repositories;

namespace Blog.Core.Service.Impl
{
    public class ArticleServiceImpl : ArticleService
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly Queries queries;

        public ArticleServiceImpl(IRepository repository, IMapper mapper, Queries queries)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.queries = queries;
        }

        public void Add(AddArticleInput input)
        {
            var article = mapper.Map<Article>(input);
            repository.Add(article);
        }

        public ArticleViewOutput Get(Guid id)
        {
            var article = repository.Get(queries.GetArticle(id));
            return mapper.Map<ArticleViewOutput>(article);
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
                Data = mapper.MapList<Article, ArticleListItemOutput>(articles),
            };
        }

        public ArticleEditOutput Detail(Guid id)
        {
            var article = repository.Get(queries.GetArticle(id));
            return mapper.Map<ArticleEditOutput>(article);
        }

        public void Edit(ArticleEditInput input)
        {
            var article = mapper.Map<ArticleEditInput, Article>(input);
            repository.Update(article);
        }

        public void Delete(Guid id)
        {
            var article = Article.Of(id);
            repository.Remove(article);
        }
    }
}