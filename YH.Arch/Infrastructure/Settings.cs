using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace YH.Arch.Infrastructure
{
    public static class Settings
    {
        public static JsonSerializerSettings JsonSerializer = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateFormatString = "yyyy-MM-dd HH:mm:ss"
        };
    }
}
