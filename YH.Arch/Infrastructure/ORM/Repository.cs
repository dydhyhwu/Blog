using System.Collections.Generic;
using System.Threading.Tasks;
using YH.Arch.Domain;

namespace YH.Arch.Infrastructure.ORM
{
    public interface Repository
    {
        T GetSingle<T>(QueryByEntity<T> query) where T : BaseEntity;
        IEnumerable<T> GetMulti<T>(QueryByEntity<T> query) where T : BaseEntity;
        int GetCount<T>(QueryByEntity<T> query) where T : BaseEntity;
        bool Existed<T>(QueryByEntity<T> query) where T : BaseEntity;
        void Add<T>(T entity) where T : BaseEntity;
        void Add<T>(IEnumerable<T> entities) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Update<T>(IEnumerable<T> entities) where T : BaseEntity;
        void Remove<T>(T entity) where T : BaseEntity;
        void Remove<T>(IEnumerable<T> entities) where T : BaseEntity;
        void Flush();
        Task FlushAsync();
    }
}
