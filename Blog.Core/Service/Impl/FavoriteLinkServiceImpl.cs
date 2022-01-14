using System;
using System.Collections.Generic;
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
    public class FavoriteLinkServiceImpl : FavoriteLinkService
    {
        private readonly IRepository repository;
        private readonly Queries queries;

        public FavoriteLinkServiceImpl(IRepository repository, Queries queries)
        {
            this.repository = repository;
            this.queries = queries;
        }

        public FavoriteLinkOutput Get(Guid id)
        {
            var link = repository.Get(queries.GetFavoriteLink(id));
            return link.MapTo<FavoriteLinkOutput>();
        }

        public void Add(FavoriteLinkAddInput addInput)
        {
            var link = addInput.MapTo<FavoriteLink>();
            repository.Add(link);
        }

        public PageList<FavoriteLinkOutput> List(PageListInput input)
        {
            var count = repository.Count(queries.GetFavoriteLinks());
            var list = repository.GetList(queries.GetFavoriteLinks().Paged(input.Index, input.Size));
            return new PageList<FavoriteLinkOutput>()
            {
                Count = count,
                Size = input.Size,
                Index = input.Index,
                Data = list.MapList<FavoriteLink, FavoriteLinkOutput>()
            };
        }

        public IList<FavoriteLinkOutput> All()
        {
            var links = repository.GetList(queries.GetFavoriteLinks());
            return links.MapTo<IList<FavoriteLinkOutput>>();
        }
    }
}