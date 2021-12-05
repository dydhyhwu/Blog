using Blog.Core.Domain;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm.Map
{
    public class ClassifyMap : EntityMap<Classify>
    {
        public ClassifyMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }
    }
}