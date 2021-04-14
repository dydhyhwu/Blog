using System;
using Blog.Core.Model.Output;

namespace Blog.Core.Service
{
    public interface FavoriteLinkService
    {
        FavoriteLinkOutput Get(Guid id);
    }
}
