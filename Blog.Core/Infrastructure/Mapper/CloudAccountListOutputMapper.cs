using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Output;

namespace Blog.Core.Infrastructure.Mapper
{
    public class CloudAccountListOutputMapper : ITypeConverter<TencentCloudAccount, CloudAccountListOutput>
    {
        public CloudAccountListOutput Convert(TencentCloudAccount source, CloudAccountListOutput destination,
            ResolutionContext context)
        {
            destination = new CloudAccountListOutput()
            {
                Id = source.Id,
                Name = source.Name,
                AppId = source.AppId,
                CreateTime = source.CreateTime,
            };
            return destination;
        }
    }
}