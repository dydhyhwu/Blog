using System;
using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output;

[AutoMap(typeof(CodeSnippet))]
public class CodeSnippetDetailOutput
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public string Content { get; set; }
    public DateTime CreateTime { get; set; }
}