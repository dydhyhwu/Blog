﻿using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Input;

[AutoMap(typeof(CodeSnippet), ReverseMap = true)]
public class AddCodeSnippetInput
{
    public string Title { get; set; }
    public string Language { get; set; }
    public string Content { get; set; }
}