using System;
using Blog.Core.Domain;
using ZeroSum.Domain.Entities;
using ZeroSum.Domain.Repositories;

namespace Blog.Core.Infrastructure.Orm
{
    public interface Queries
    {
        IQuery<FavoriteLink> GetFavoriteLink(Guid id);
        IQuery<Article> GetArticle(Guid id);
        QueryByEntity<Article> GetArticles();
        QueryByEntity<FavoriteLink> GetFavoriteLinks();
        IQuery<Category> GetCategoryBy(string name);
        QueryByEntity<Category> GetCategories();
        IQuery<Category> GetCategoryBy(Guid id);
        QueryByEntity<TencentCloudAccount> GetCloudAccountBy(Guid id);
        QueryByEntity<TencentCloudAccount> GetCLoudAccount();
        IQuery<CosProvider> GetCosProviderBy(Guid id);
        IQuery<CosProvider> GetCosProvider();
        IQuery<CosProvider> GetEnableCosProvider();
        IQuery<CodeSnippet> GetCodeSnippetBy(Guid id);
        IQuery<CodeSnippet> GetCodeSnippet();
    }
}
