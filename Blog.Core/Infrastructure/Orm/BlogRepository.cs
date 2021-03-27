using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm
{
    public class BlogRepository : EFCoreRepository<BlogContext>
    {
        public BlogRepository(BlogContext context) : base(context)
        {
        }
    }
}
