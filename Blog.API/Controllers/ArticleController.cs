﻿using System;
using Blog.Core.Infrastructure;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using Blog.Core.Service;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public ArticleEditOutput Detail(Guid id)
        {
            return service.Detail(id);
        }

        [HttpPost]
        public void Edit(ArticleEditInput input)
        {
            service.Edit(input);
        }

        [HttpPost]
        public void Delete(ArticleDeleteInput input)
        {
            service.Delete(input.Id);
        }
    }
}
