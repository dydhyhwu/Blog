using Blog.Core.Domain;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm.Map
{
    public class ArticleMap : EntityMap<Article>
    {
        public ArticleMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            _builder.ToTable(nameof(Article));
        }
    }
}
