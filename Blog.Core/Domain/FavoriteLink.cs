using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ZeroSum.Attributes;

namespace Blog.Core.Domain
{
    [Entity]
    [Table(nameof(FavoriteLink))]
    [Description("收藏链接")]
    public class FavoriteLink : Content
    {
        public string Description { get; set; }
    }
}