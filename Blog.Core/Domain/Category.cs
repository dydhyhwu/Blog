using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using YH.Arch.Domain;

namespace Blog.Core.Domain
{
    [Table(nameof(Category))]
    [Description("类别")]
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }
}