using System;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output
{
    [AutoMap(typeof(Article))]
    public class ArticleViewOutput
    {
        public Guid Id { get; set; }
        public ContentType Type { get; set; }
        public string Title { get; set; }
        
        [SourceMember(nameof(Article.Value))]
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}