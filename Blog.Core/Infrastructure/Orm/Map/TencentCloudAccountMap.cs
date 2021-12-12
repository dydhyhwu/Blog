using Blog.Core.Domain;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm.Map
{
    public class TencentCloudAccountMap: EntityMap<TencentCloudAccount>
    {
        public TencentCloudAccountMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }
    }
}