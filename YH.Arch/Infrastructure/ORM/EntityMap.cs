using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YH.Arch.Infrastructure.ORM
{
    public abstract class EntityMap<TEntity> : IEntityMap
        where TEntity : class
    {
        protected readonly EntityTypeBuilder<TEntity> _builder;

        protected EntityMap(ModelBuilder modelBuilder)
        {
            _builder = modelBuilder.Entity<TEntity>();
        }
    }
}