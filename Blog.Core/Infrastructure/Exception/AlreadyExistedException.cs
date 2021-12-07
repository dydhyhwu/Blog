using YH.Arch.Infrastructure.Exception;

namespace Blog.Core.Infrastructure.Exception
{
    public class AlreadyExistedException : BusinessException
    {
        public AlreadyExistedException(string msg): base(msg)
        {
        }
    }
}