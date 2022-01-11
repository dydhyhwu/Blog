using System;
using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output
{
    [AutoMap(typeof(FavoriteLink))]
    public class FavoriteLinkOutput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}