using System;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using Blog.Core.Service;
using Microsoft.AspNetCore.Mvc;
using YH.Arch.Infrastructure;

namespace Blog.API.Controllers
{
    public class FavoriteLinkController : BaseController
    {
        private readonly FavoriteLinkService service;

        public FavoriteLinkController(FavoriteLinkService service)
        {
            this.service = service;
        }

        [HttpGet]
        public FavoriteLinkOutput Get(Guid id)
        {
            return service.Get(id);
        }

        [HttpPost]
        public void Add(FavoriteLinkAddInput addInput)
        {
            service.Add(addInput);
        }

        [HttpGet]
        public PageList<FavoriteLinkOutput> List([FromQuery]PageListInput input)
        {
            return service.List(input);
        }
    }
}
