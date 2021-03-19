using System;

namespace YH.Arch.Domain
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
