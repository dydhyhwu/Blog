using System;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Infrastructure.Orm;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using ZeroSum.Domain.Repositories;

namespace Blog.Core.Service.Impl
{
    public class FavoriteLinkServiceImpl : FavoriteLinkService
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly Queries queries;

        public FavoriteLinkServiceImpl(IRepository repository, IMapper mapper, Queries queries)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.queries = queries;
        }

        public FavoriteLinkOutput Get(Guid id)
        {
            var link = repository.Get(queries.GetFavoriteLink(id));
            return mapper.Map<FavoriteLinkOutput>(link);
        }

        public void Add(FavoriteLinkAddInput addInput)
        {
            var link = mapper.Map<FavoriteLink>(addInput);
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
                Data = mapper.MapList<FavoriteLink, FavoriteLinkOutput>(list)
            };
        }
    }
}