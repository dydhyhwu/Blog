using System;
using Blog.Core.Domain;
using YH.Arch.Domain;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm
{
    public interface Queries
    {
        Query<FavoriteLink> GetFavoriteLink(Guid id);
        Query<Article> GetArticle(Guid id);
        QueryByEntity<Article> GetArticles();
        QueryByEntity<FavoriteLink> GetFavoriteLinks();
        Query<Category> GetCategoryBy(string name);
        QueryByEntity<Category> GetCategories();
        Query<Category> GetCategoryBy(Guid id);
        QueryByEntity<TencentCloudAccount> GetCloudAccountBy(Guid id);
        QueryByEntity<TencentCloudAccount> GetCLoudAccount();
        Query<CosProvider> GetCosProviderBy(Guid id);
        Query<CosProvider> GetCosProvider();
    }
}
