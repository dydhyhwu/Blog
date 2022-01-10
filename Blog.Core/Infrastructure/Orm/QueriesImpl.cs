using System;
using System.Linq;
using Blog.Core.Domain;
using ZeroSum.Domain.Repositories;

namespace Blog.Core.Infrastructure.Orm
{
    public class QueriesImpl : Queries
    {
        public IQuery<FavoriteLink> GetFavoriteLink(Guid id)
        {
            return QueryByEntity<FavoriteLink>.Of(query =>
            {
                return query.Where(x => x.Id == id);
            });
        }

        public IQuery<Article> GetArticle(Guid id)
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
            return QueryByEntity<FavoriteLink>.Of(query => query);
        }

        public IQuery<Category> GetCategoryBy(string name)
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

        public IQuery<Category> GetCategoryBy(Guid id)
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

        public QueryByEntity<TencentCloudAccount> GetCLoudAccount()
        {
            return QueryByEntity<TencentCloudAccount>.Of(query => query.OrderByDescending(x => x.CreateTime));
        }

        public IQuery<CosProvider> GetCosProviderBy(Guid id)
        {
            return QueryByEntity<CosProvider>.Of(query => query.Where(x => x.Id == id));
        }

        public IQuery<CosProvider> GetCosProvider()
        {
            return QueryByEntity<CosProvider>.Of(query => query.OrderByDescending(x => x.CreateTime));
        }

        public IQuery<CosProvider> GetEnableCosProvider()
        {
            return QueryByEntity<CosProvider>.Of(query => query.Where(x => x.Enable == true));
        }
    }
}