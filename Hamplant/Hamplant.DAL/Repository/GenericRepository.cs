using System;
using System.Collections.Generic;
using System.Linq;
using Hamplant.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Hamplant.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private HamplantContext dbContext;
        private DbSet<T> dbSet;

        public GenericRepository(HamplantContext dbContext, DbSet<T> dbSet)
        {
            this.dbContext = dbContext;
            this.dbSet = dbSet;
        }

        public object QueryExtensions { get; private set; }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public T GetById(Guid id)
        {
            return this.dbSet.Find(id);
        }

        public IEnumerable<T> GetByIds(ICollection<Guid> ids)
        {
            if (ids == null || ids.Any() == false)
            {
                return Enumerable.Empty<T>().AsQueryable();
            }

            return this.dbSet.Where(p => ids.Contains(p.Id));
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
