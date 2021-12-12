using Blog.Core.Domain;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm.Map
{
    public class CosProviderMap : EntityMap<CosProvider>
    {
        public CosProviderMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }
    }
}