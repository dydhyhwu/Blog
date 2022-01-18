using System.ComponentModel.DataAnnotations;
using ZeroSum.Attributes;

namespace Blog.Core.Domain;

/// <summary>
/// 代码片段，用于随手记录一些代码段，脚本
/// </summary>
[Entity]
public class CodeSnippet : BaseEntity
{
    /// <summary>
    /// 所属语言（不使用枚举，因为不需要对其进行处理）
    /// 只是用于标识，以及渲染时根据语言来进行关键字识别
    /// </summary>
    [MaxLength(32)]
    public string Language { get; set; }
    
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }
}