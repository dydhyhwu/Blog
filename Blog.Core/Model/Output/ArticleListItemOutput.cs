using System;
using AutoMapper;
using Blog.Core.Domain;

namespace Blog.Core.Model.Output
{
    [AutoMap(typeof(Article))]
    public class ArticleListItemOutput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
    }
}