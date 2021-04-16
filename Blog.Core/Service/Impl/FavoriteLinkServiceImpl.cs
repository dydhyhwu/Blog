using System;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Service.Impl
{
    public class FavoriteLinkServiceImpl : FavoriteLinkService
    {
        private readonly Repository repository;
        private readonly IMapper mapper;

        public FavoriteLinkServiceImpl(Repository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public FavoriteLinkOutput Get(Guid id)
        {
            return new FavoriteLinkOutput()
            {
                Title = "Bilibli下载器",
                Description = "目前还挺好的一个下载器",
                Content = "https://github.com/SigureMo/bilili",
            };
        }

        public void Add(FavoriteLinkAddInput addInput)
        {
            var link = mapper.Map<FavoriteLink>(addInput);
            repository.Add(link);
        }
    }
}