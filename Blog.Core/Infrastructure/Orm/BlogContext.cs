using System.Reflection;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.Extension;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm
{
    public class BlogContext : BaseContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityMapsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
