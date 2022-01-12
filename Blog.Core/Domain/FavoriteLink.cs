using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZeroSum.Attributes;

namespace Blog.Core.Domain
{
    [Entity]
    [Table(nameof(FavoriteLink))]
    [Description("收藏链接")]
    public class FavoriteLink : BaseEntity
    {
        [MaxLength(255)]
        public string Title { get; set; }
        
        public string Value { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
    }
}