﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ZeroSum.Attributes;

namespace Blog.Core.Domain
{
    [Entity]
    [Table(nameof(Classify))]
    [Description("分类（关联类别和文章）")]
    public class Classify : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid ArticleId { get; set; }
    }
}