using System.Collections.Generic;
using Blog.Core.Service.Impl;

namespace Blog.Core.Service
{
    public interface ICosService
    {
        public StsClientCredential GetTempToken(Dictionary<string, object> config);
    }
}