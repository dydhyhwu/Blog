using System;
using System.Linq;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Output;

namespace Blog.Core.Infrastructure.Mapper
{
    public class CosProviderListOutputMapper : ITypeConverter<CosProvider, CloudProviderListOutput>
    {
        public CloudProviderListOutput Convert(CosProvider source, CloudProviderListOutput destination,
            ResolutionContext context)
        {
            var actions = source.AllowActions.Split(',').Select(Enum.Parse<TencentStsAction>);
            destination = new CloudProviderListOutput()
            {
                Id = source.Id,
                AccountId = source.Account.Id,
                Region = source.Region,
                BucketName = source.BucketName,
                Duration = source.Duration,
                AllowPrefix = source.AllowPrefix,
            };
            return destination;
        }
    }
}