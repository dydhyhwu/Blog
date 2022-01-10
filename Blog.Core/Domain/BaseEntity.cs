using System;
using ZeroSum.Domain.Entities;

namespace Blog.Core.Domain
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class BaseEntity : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
