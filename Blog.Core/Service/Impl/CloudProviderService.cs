using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Infrastructure.Orm;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using YH.Arch.Infrastructure.Extension;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Service.Impl
{
    public class CloudProviderService : ICloudProviderService
    {
        private readonly Repository repository;
        private readonly Queries queries;
        private readonly IMapper mapper;

        public CloudProviderService(Repository repository, Queries queries, IMapper mapper)
        {
            this.repository = repository;
            this.queries = queries;
            this.mapper = mapper;
        }

        public void Add(AddCloudProviderInput input)
        {
            var account = GetAccount(input.AccountId);
            var provider = new CosProvider
            {
                Account = account,
                Region = input.Region,
                BucketName = input.Name,
                Duration = input.Duration,
                AllowPrefix = input.AllowPrefix,
                AllowActions = string.Join(",", input.AllowActions)
            };
            
            repository.Add(provider);
        }

        public void Delete(Guid id)
        {
            var provider = GetProvider(id);
            repository.Remove(provider);
        }

        public void Edit(EditCloudProviderInput input)
        {
            var provider = GetProvider(input.Id);
            var account = GetAccount(input.AccountId);
            provider.Account = account;
            provider.Region = input.Region;
            provider.BucketName = input.BucketName;
            provider.Duration = input.Duration;
            provider.AllowPrefix = input.AllowPrefix;
            provider.AllowActions = string.Join(",", input.AllowActions);
            repository.Update(provider);
        }

        public CloudProviderOutput Detail(Guid id)
        {
            var provider = GetProvider(id);
            var actions = provider.AllowActions.Split(',').Select(Enum.Parse<TencentStsAction>);
            return new()
            {
                Id = provider.Id,
                AccountId = provider.Account.Id,
                Region = provider.Region,
                BucketName = provider.BucketName,
                Duration = provider.Duration,
                AllowPrefix = provider.AllowPrefix,
                AllowActions = actions.ToList(),
                Enable = provider.Enable
            };
        }

        public IList<CloudProviderListOutput> List()
        {
            var list = repository.GetMulti(queries.GetCosProvider()).ToList();
            return mapper.MapList<CosProvider, CloudProviderListOutput>(list);
        }

        public void SetEnable(Guid id)
        {
            var query = queries.GetEnableCosProvider();
            if (repository.Existed(query))
            {
                var enableProvider = repository.GetSingle(query);
                enableProvider.IsDisable();
                repository.Update(enableProvider);
            }

            var provider = repository.GetSingle(queries.GetCosProviderBy(id));
            provider.IsEnable();
            repository.Update(provider);
        }

        private CosProvider GetProvider(Guid id)
        {
            return repository.GetSingle(queries.GetCosProviderBy(id));
        }

        private TencentCloudAccount GetAccount(Guid id)
        {
            return repository.GetSingle(queries.GetCloudAccountBy(id));
        }
    }
}