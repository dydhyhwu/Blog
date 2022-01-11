using System;
using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output
{
    [AutoMap(typeof(Article))]
    public class ArticleViewOutput
    {
        public Guid Id { get; set; }
        public ContentFormat Format { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}