using System;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;

namespace Blog.Core.Service;

public interface ICodeSnippetService
{
    void Add(AddCodeSnippetInput input);
    void Remove(Guid id);
    CodeSnippetDetailOutput Get(Guid id);
    void Edit(EditCodeSnippetInput input);
    PageList<CodeSnippetItemOutput> List(PageListInput input);
}