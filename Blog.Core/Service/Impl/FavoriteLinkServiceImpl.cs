using System;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Infrastructure.Orm;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Service.Impl
{
    public class FavoriteLinkServiceImpl : FavoriteLinkService
    {
        private readonly Repository repository;
        private readonly IMapper mapper;
        private readonly Queries queries;

        public FavoriteLinkServiceImpl(Repository repository, IMapper mapper, Queries queries)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.queries = queries;
        }

        public FavoriteLinkOutput Get(Guid id)
        {
            var link = repository.GetSingle(queries.GetFavoriteLink(id));
            return mapper.Map<FavoriteLinkOutput>(link);
        }

        public void Add(FavoriteLinkAddInput addInput)
        {
            var link = mapper.Map<FavoriteLink>(addInput);
            repository.Add(link);
        }
    }
}