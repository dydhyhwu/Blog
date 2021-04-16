using System;
using System.Linq;
using Blog.Core.Domain;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm
{
    public class QueriesImpl : Queries
    {
        public Query<FavoriteLink> GetFavoriteLink(Guid id)
        {
            return QueryByEntity<FavoriteLink>.Of(query =>
            {
                return query.Where(x => x.Id == id);
            });
        }
    }
}