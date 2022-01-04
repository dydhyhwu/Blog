using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain
{
    [Table(nameof(FavoriteLink))]
    [Description("收藏链接")]
    public class FavoriteLink : Content
    {
        public string Description { get; set; }
    }
}