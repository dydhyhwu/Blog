using Blog.Core.Domain;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm.Map
{
    public class ContentMap : EntityMap<Content>
    {
        public ContentMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }
    }
}
