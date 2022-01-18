using System;
using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output;

[AutoMap(typeof(CodeSnippet))]
public class CodeSnippetItemOutput
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public DateTime CreateTime { get; set; }
}