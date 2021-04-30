using System;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;

namespace Blog.Core.Service
{
    public interface FavoriteLinkService
    {
        FavoriteLinkOutput Get(Guid id);
        void Add(FavoriteLinkAddInput addInput);
        PageList<FavoriteLinkOutput> List(PageListInput input);
    }
}
