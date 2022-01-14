using System;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output
{
    [AutoMap(typeof(FavoriteLink))]
    public class FavoriteLinkOutput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
        [SourceMember(nameof(FavoriteLink.Value))]
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}