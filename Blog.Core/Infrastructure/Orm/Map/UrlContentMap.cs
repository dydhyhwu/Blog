using Blog.Core.Domain;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm.Map
{
    public class UrlContentMap : EntityMap<FavoriteLink>
    {
        public UrlContentMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            _builder.ToTable(nameof(FavoriteLink));
        }
    }
}
