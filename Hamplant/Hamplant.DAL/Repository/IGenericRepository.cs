using Hamplant.DAL.Model;
using System;
using System.Collections.Generic;

namespace Hamplant.DAL.Repository
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        void Add(T entity);

        void Delete(T entity);

        T GetById(Guid id);

        IEnumerable<T> GetByIds(ICollection<Guid> ids);

        void Save();
    }
}
