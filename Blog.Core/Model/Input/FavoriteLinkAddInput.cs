using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Model.Input
{
    public class FavoriteLinkAddInput
    {
        [Required(ErrorMessage = "标题必须")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}