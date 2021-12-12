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

        public Query<Article> GetArticle(Guid id)
        {
            return QueryByEntity<Article>.Of(query =>
            {
                return query.Where(x => x.Id == id);
            });
        }

        public QueryByEntity<Article> GetArticles()
        {
            return QueryByEntity<Article>.Of(query =>
            {
                return query.OrderByDescending(x => x.CreateTime);
            });
        }

        public QueryByEntity<FavoriteLink> GetFavoriteLinks()
        {
            return QueryByEntity<FavoriteLink>.Of(query =>
            {
                return query;
            });
        }

        public Query<Category> GetCategoryBy(string name)
        {
            return QueryByEntity<Category>.Of(query =>
            {
                return query.Where(x => x.Name == name);
            });
        }

        public QueryByEntity<Category> GetCategories()
        {
            return QueryByEntity<Category>.Of(query => query);
        }

        public Query<Category> GetCategoryBy(Guid id)
        {
            return QueryByEntity<Category>.Of(query =>
            {
                return query.Where(x => x.Id == id);
            });
        }

        public QueryByEntity<TencentCloudAccount> GetCloudAccountBy(Guid id)
        {
            return QueryByEntity<TencentCloudAccount>.Of(query =>
            {
                return query.Where(x => x.Id == id);
            });
        }
    }
}