using System;
using System.Linq;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Infrastructure.Exception;
using Blog.Core.Infrastructure.Orm;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using YH.Arch.Infrastructure.Extension;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Service.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly Repository repository;
        private readonly Queries queries;
        private readonly IMapper mapper;

        public CategoryService(Repository repository, Queries queries, IMapper mapper)
        {
            this.repository = repository;
            this.queries = queries;
            this.mapper = mapper;
        }

        public void Add(AddCategoryInput input)
        {
            if (Existed(input.Name)) throw new AlreadyExistedException($"分类[${input.Name}]已存在");
            var category = new Category()
            {
                Name = input.Name
            };
            repository.Add(category);
        }

        public PageList<CategoryListOutput> List(PageListInput input)
        {
            var query = queries.GetCategories();
            var count = repository.GetCount(query);
            query = query.PaginationBy(input.Index, input.Size);
            var categories = repository.GetMulti(query).ToList();
            return new PageList<CategoryListOutput>()
            {
                Index = input.Index,
                Size = input.Size,
                Count = count,
                Data = mapper.MapList<Category, CategoryListOutput>(categories)
            };
        }

        public void Delete(Guid id)
        {
            var category = repository.GetSingle(queries.GetCategoryBy(id));
            repository.Remove(category);
        }

        public void Edit(CategoryEditInput input)
        {
            var category = repository.GetSingle(queries.GetCategoryBy(input.Id));
            if (input.Name == category.Name) return;
            if (Existed(input.Name)) throw new AlreadyExistedException($"分类[${input.Name}]已存在");
            category.Name = input.Name;
            repository.Update(category);
        }

        private bool Existed(string name)
        {
            return repository.Existed(queries.GetCategoryBy(name));
        }
    }
}