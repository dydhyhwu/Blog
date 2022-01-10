﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Infrastructure.Orm;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using YH.Arch.Infrastructure.Exception;
using YH.Arch.Infrastructure.Extension;
using ZeroSum.Domain.Repositories;

namespace Blog.Core.Service.Impl
{
    public class CloudProviderService : ICloudProviderService
    {
        private readonly IRepository repository;
        private readonly Queries queries;
        private readonly IMapper mapper;
        private readonly ICosService cosService;

        public CloudProviderService(IRepository repository, Queries queries, IMapper mapper, ICosService cosService)
        {
            this.repository = repository;
            this.queries = queries;
            this.mapper = mapper;
            this.cosService = cosService;
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
                AllowActions = string.Join(",", input.AllowActions),
                UploadPrefix = input.UploadPrefix,
                Host = input.Host,
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
            provider.UploadPrefix = input.UploadPrefix;
            provider.Host = input.Host;
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
                Enable = provider.Enable,
                UploadPrefix = provider.UploadPrefix,
                Host = provider.Host
            };
        }

        public IList<CloudProviderListOutput> List()
        {
            var list = repository.GetList(queries.GetCosProvider());
            return mapper.MapList<CosProvider, CloudProviderListOutput>(list);
        }

        public void SetEnable(Guid id)
        {
            var query = queries.GetEnableCosProvider();
            if (repository.Existed(query))
            {
                var enableProvider = repository.Get(query);
                enableProvider.IsDisable();
                repository.Update(enableProvider);
            }

            var provider = repository.Get(queries.GetCosProviderBy(id));
            provider.IsEnable();
            repository.Update(provider);
        }

        public TempCredentialOutput GenerateCredential()
        {
            var query = queries.GetEnableCosProvider();
            if (!repository.Existed(query)) throw new BusinessException("未设置默认存储，请先设置默认存储！");
            var provider = repository.Get(query);
            var config = provider.GenerateConfig();
            var result = cosService.GetTempToken(config.AsDictionary());
            return new TempCredentialOutput()
            {
                Token = result.Credentials.Token,
                SecretId = result.Credentials.TmpSecretId,
                SecretKey = result.Credentials.TmpSecretKey,
                StartTime = result.StartTime,
                ExpiredTime = result.ExpiredTime
            };
        }

        public CosProviderConfigOutput GetEnableProviderConfig()
        {
            var query = queries.GetEnableCosProvider();
            if (!repository.Existed(query)) throw new BusinessException("未设置默认存储，请先设置默认存储！");
            var provider = repository.Get(query);
            var config = provider.GenerateConfig();
            return new CosProviderConfigOutput()
            {
                Bucket = config.Bucket,
                Region = config.Region,
                UploadPrefix = provider.UploadPrefix,
                Host = provider.Host
            };
        }

        private CosProvider GetProvider(Guid id)
        {
            return repository.Get(queries.GetCosProviderBy(id));
        }

        private TencentCloudAccount GetAccount(Guid id)
        {
            return repository.Get(queries.GetCloudAccountBy(id));
        }
    }
}