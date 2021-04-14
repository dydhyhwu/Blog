using System;
using Blog.Core.Model.Output;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Service.Impl
{
    public class FavoriteLinkServiceImpl : FavoriteLinkService
    {
        private readonly Repository repository;

        public FavoriteLinkServiceImpl(Repository repository)
        {
            this.repository = repository;
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
    }
}