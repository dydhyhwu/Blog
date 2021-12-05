using Blog.Core.Domain;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm.Map
{
    public class CategoryMap : EntityMap<Category>
    {
        public CategoryMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }
    }
}