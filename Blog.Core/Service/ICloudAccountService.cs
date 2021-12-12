using System;
using System.Collections.Generic;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;

namespace Blog.Core.Service
{
    public interface ICloudAccountService
    {
        void Add(AddCloudAccountInput input);
        void Edit(EditCloudAccountInput input);
        CloudAccountOutput Detail(Guid id);
        void Delete(Guid id);
        IList<CloudAccountListOutput> List();
    }
}