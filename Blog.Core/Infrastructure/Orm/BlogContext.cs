using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm
{
    public class BlogContext : BaseContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }
    }
}
