using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Input
{
    [AutoMap(typeof(FavoriteLink), ReverseMap = true)]
    public class FavoriteLinkAddInput
    {
        [Required(ErrorMessage = "标题必须")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}