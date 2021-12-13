using System;
using System.Collections.Generic;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;

namespace Blog.Core.Service
{
    public interface ICloudProviderService
    {
        void Add(AddCloudProviderInput input);
        void Delete(Guid id);
        void Edit(EditCloudProviderInput input);
        CloudProviderOutput Detail(Guid id);
        IList<CloudProviderListOutput> List();
    }
}