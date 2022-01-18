using System.Collections.Generic;

namespace Blog.Core.Model
{
    public class PageList<T>
    {
        public int Count { get; set; }

        public int Page
        {
            get
            {
                return Count / Size + (Count % Size == 0 ? 0 : 1);
            }
        }

        public int Size { get; set; } = 15;
        public IList<T> Data { get; set; }
        public int Index { get; set; } = 1;

        /// <summary>
        /// 工厂方法创建，分页大小默认为15，默认为第一页
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="count">数据总数</param>
        /// <returns></returns>
        public static PageList<T> Of(IList<T> data, int count)
        {
            return new PageList<T>()
            {
                Data = data,
                Count = count
            };
        }

        /// <summary>
        /// 设置分页参数
        /// </summary>
        /// <param name="index">当前页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public PageList<T> PageBy(int index, int size)
        {
            Index = index;
            Size = size;
            return this;
        }
    }
}