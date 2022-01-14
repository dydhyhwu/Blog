using System.Collections.Generic;
using Blog.Core.Infrastructure;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using Blog.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpPost]
        public void Add(AddCategoryInput input)
        {
            service.Add(input);
        }

        [HttpGet]
        public PageList<CategoryListOutput> List([FromQuery]PageListInput input)
        {
            return service.List(input);
        }

        [HttpPost]
        public void Delete(CategoryDeleteInput input)
        {
            service.Delete(input.Id);
        }
        
        [HttpPost]
        public void Edit(CategoryEditInput input)
        {
            service.Edit(input);
        }

        [HttpGet]
        public IList<CategoryListOutput> All()
        {
            return service.All();
        }
    }
}