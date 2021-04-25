using System;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;

namespace Blog.Core.Service
{
    public interface ArticleService
    {
        void Add(AddArticleInput input);
        ArticleViewOutput Get(Guid id);
        PageList<ArticleListItemOutput> List(PageListInput input);
    }
}