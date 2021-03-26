using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using YH.Arch.Domain;

namespace YH.Arch.Infrastructure.ORM
{
    public class EFCoreRepository<TContext> : Repository 
        where TContext : DbContext
    {
        private readonly TContext context;

        public EFCoreRepository(TContext context)
        {
            this.context = context;
        }

        public T GetSingle<T>(Query<T> query) where T : BaseEntity
        {
            if (query is QueryByEntity<T> entityQuery)
            {
                return Query(entityQuery).First();
            }
            throw new System.Exception($"不支持的Query类型: {typeof(Query<>)}");
        }

        public IEnumerable<T> GetMulti<T>(Query<T> query) where T : BaseEntity
        {
            if (query is QueryByEntity<T> entityQuery)
            {
                return Query(entityQuery).ToList();
            }
            throw new System.Exception($"不支持的Query类型: {typeof(Query<>)}");
        }

        public int GetCount<T>(Query<T> query) where T : BaseEntity
        {
            if (query is QueryByEntity<T> entityQuery)
            {
                return Query(entityQuery).Count();
            }
            throw new System.Exception($"不支持的Query类型: {typeof(Query<>)}");
        }

        public bool Existed<T>(Query<T> query) where T : BaseEntity
        {
            if (query is QueryByEntity<T> entityQuery)
            {
                return Query(entityQuery).Any();
            }
            throw new System.Exception($"不支持的Query类型: {typeof(Query<>)}");
        }

        public void Add<T>(T entity) where T : BaseEntity
        {
            Entity<T>().Add(entity);
        }

        public void Add<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            Entity<T>().AddRange(entities);
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            Entity<T>().Update(entity);
        }

        public void Update<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            Entity<T>().UpdateRange(entities);
        }

        public void Remove<T>(T entity) where T : BaseEntity
        {
            Entity<T>().Remove(entity);
        }

        public void Remove<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            Entity<T>().RemoveRange(entities);
        }

        public void Flush()
        {
            this.context.SaveChanges();
        }

        public Task FlushAsync()
        {
            return this.context.SaveChangesAsync();
        }

        public DatabaseFacade GetDatabase()
        {
            return context.Database;
        }

        private DbSet<T> Entity<T>() where T : BaseEntity
        {
            return context.Set<T>();
        }

        private IQueryable<T> Query<T>(QueryByEntity<T> entityQuery) where T : BaseEntity
        {
            var query = Entity<T>().AsQueryable();
            query = entityQuery.Query(query);

            if (entityQuery.HasPagination)
            {
                query = query.Skip(entityQuery.PageOffset).Take(entityQuery.PageSize);
            }

            return query;
        }
    }
}