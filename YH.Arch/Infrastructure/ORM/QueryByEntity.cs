using System;
using System.Linq;
using YH.Arch.Domain;

namespace YH.Arch.Infrastructure.ORM
{
    public class QueryByEntity<T> : Query<T>
        where T : BaseEntity
    {
        public Func<IQueryable<T>, IQueryable<T>> Query { get; }

        private QueryByEntity(Func<IQueryable<T>, IQueryable<T>> query)
        {
            Query = query;
        }

        public static QueryByEntity<T> Of(Func<IQueryable<T>, IQueryable<T>> query)
        {
            return new QueryByEntity<T>(query);
        }

        public QueryByEntity<T> PaginationBy(int page, int size)
        {
            PageOffset = (page - 1) * size;
            PageSize = size;
            HasPagination = true;
            return this;
        }

        public int PageSize { get; protected set; }
        public int PageOffset { get; protected set; }

        public bool HasPagination { get; protected set; }
    }
}