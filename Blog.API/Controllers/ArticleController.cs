using System;
using System.Collections.Generic;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using Blog.Core.Service;
using Microsoft.AspNetCore.Mvc;
using YH.Arch.Infrastructure;

namespace Blog.API.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly ArticleService service;

        public ArticleController(ArticleService service)
        {
            this.service = service;
        }

        [HttpPost]
        public void Add(AddArticleInput input)
        {
            service.Add(input);
        }

        [HttpGet]
        public ArticleViewOutput Get(Guid id)
        {
            return service.Get(id);
        }

        [HttpGet]
        public PageList<ArticleListItemOutput> List([FromQuery]PageListInput input)
        {
            return service.List(input);
        }
    }
}
