using System.Collections.Generic;
using Newtonsoft.Json;
using ZeroSum.DependencyInjection.Attributes;

namespace Blog.Core.Service.Impl
{
    [Register]
    public class CosService : ICosService
    {
        public CosService()
        {
        }

        public StsClientCredential GetTempToken(Dictionary<string,object> config)
        {
            var client = COSSTS.STSClient.genCredential(config);
            var res = JsonConvert.SerializeObject(client);
            return JsonConvert.DeserializeObject<StsClientCredential>(res);
        }
    }
}