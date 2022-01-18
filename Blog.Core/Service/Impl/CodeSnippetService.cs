using System;
using System.Collections.Generic;
using Blog.Core.Domain;
using Blog.Core.Infrastructure.Orm;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using ZeroSum.DependencyInjection.Attributes;
using ZeroSum.Domain.Repositories;
using ZeroSum.Extend.Mapper.Extensions;

namespace Blog.Core.Service.Impl;

[Register]
public class CodeSnippetService : ICodeSnippetService
{
    private readonly IRepository repository;
    private readonly Queries queries;

    public CodeSnippetService(IRepository repository, Queries queries)
    {
        this.repository = repository;
        this.queries = queries;
    }

    public void Add(AddCodeSnippetInput input)
    {
        var snippet = input.MapTo<CodeSnippet>();
        repository.Add(snippet);
    }

    public void Remove(Guid id)
    {
        repository.Remove(queries.GetCodeSnippetBy(id));
    }

    public CodeSnippetDetailOutput Get(Guid id)
    {
        var snippet = repository.Get(queries.GetCodeSnippetBy(id));
        return snippet.MapTo<CodeSnippetDetailOutput>();
    }

    public void Edit(EditCodeSnippetInput input)
    {
        var snippet = input.MapTo<CodeSnippet>();
        repository.Update(snippet);
    }

    public PageList<CodeSnippetItemOutput> List(PageListInput input)
    {
        var query = queries.GetCodeSnippet();
        var count = repository.Count(query);
        var list = repository.GetList(query.Paged(input.Index, input.Size)).MapTo<IList<CodeSnippetItemOutput>>();
        return PageList<CodeSnippetItemOutput>.Of(list, count).PageBy(input.Index, input.Size);
    }
}