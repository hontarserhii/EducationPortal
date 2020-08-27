using EducationPortal.Core;
using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Repository
{
    public class Repository : IEFRepository
    {
        private readonly IEducationPortalContext database;

        public Repository(IEducationPortalContext database)
        {
            this.database = database;
        }

        public int Create<T>(T entity) where T : BaseEntity
        {
            database.Set<T>().Add(entity);
            database.SaveChanges();
            int id = entity.Id;
            return id;
        }

        public bool Delete<T>(int id) where T : BaseEntity
        {
            var entity = database.Set<T>().Find(id);
            if (entity != null)
            {
                database.Set<T>().Remove(entity);
                database.SaveChanges();
                return true;
            }
            return false;
        }

        public T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            var entity = database.Set<T>().Where(predicate).FirstOrDefault();
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public T LastOrDefault<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            var entity = database.Set<T>().Where(predicate).LastOrDefault();
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public T Get<T>(int id) where T : BaseEntity
        {
            var entity = database.Set<T>().Find(id);
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            var entity = database.Set<T>().Where(predicate);
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public int Count<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return database.Set<T>().Where(predicate).Count();
        }
        
        public void Update<T>(T entity) where T : BaseEntity
        {
            database.Entry(entity).State = EntityState.Modified;
            database.SaveChanges();
        }

        public IEnumerable<T> GetAll<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetBlock<T>(Expression<Func<T, bool>> predicate, int skip, int count) where T : BaseEntity
        {
            var entity = database.Set<T>().Where(predicate).OrderBy(c => c.Id). Skip(skip).Take(count);
            if (entity != null)
            {
                return entity;
            }
            return null;
        }
    }
}
