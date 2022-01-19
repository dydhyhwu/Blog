using System;
using Blog.Core.Infrastructure;
using Blog.Core.Model;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using Blog.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

/// <summary>
/// 代码片段控制器
/// </summary>
public class CodeSnippetController : BaseController
{
    private readonly ICodeSnippetService service;

    public CodeSnippetController(ICodeSnippetService service)
    {
        this.service = service;
    }

    /// <summary>
    /// 新增代码片段
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public void Add(AddCodeSnippetInput input)
    {
        service.Add(input);
    }

    /// <summary>
    /// 删除代码片段
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public void Delete(DeleteCodeSnippetInput input)
    {
        service.Remove(input.Id);
    }

    /// <summary>
    /// 获取代码片段
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public CodeSnippetDetailOutput Detail(Guid id)
    {
        return service.Get(id);
    }

    /// <summary>
    /// 修改代码片段
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public void Edit(EditCodeSnippetInput input)
    {
        service.Edit(input);
    }

    /// <summary>
    /// 获取分页内容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public PageList<CodeSnippetItemOutput> List([FromQuery]PageListInput input)
    {
        return service.List(input);
    }
}