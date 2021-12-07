using System;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;

namespace Blog.Core.Service
{
    public interface ICategoryService
    {
        void Add(AddCategoryInput input);
        PageList<CategoryListOutput> List(PageListInput input);
        void Delete(Guid id);
        void Edit(CategoryEditInput input);
    }
}