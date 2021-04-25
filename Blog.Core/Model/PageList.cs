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
        public int Size { get; set; }
        public IList<T> Data { get; set; }
        public int Index { get; set; }
    }
}