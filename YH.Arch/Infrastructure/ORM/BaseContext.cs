using System.Reflection;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.Extension;

namespace YH.Arch.Infrastructure.ORM
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityMapsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
