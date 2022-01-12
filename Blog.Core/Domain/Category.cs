using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZeroSum.Attributes;

namespace Blog.Core.Domain
{
    [Entity]
    [Table(nameof(Category))]
    [Description("类别")]
    public class Category : BaseEntity
    {
        [MaxLength(60)]
        public string Name { get; set; }
    }
}