using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core
{
    public interface IEFRepository
    {
        IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        IEnumerable<T> GetAll<T>() where T : BaseEntity;

        IEnumerable<T> GetBlock<T>(Expression<Func<T, bool>> predicate, int skip, int count) where T : BaseEntity;

        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        T LastOrDefault<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        int Count<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        int Create<T>(T entity) where T : BaseEntity;

        bool Delete<T>(int id) where T : BaseEntity;

        void Update<T>(T entity) where T : BaseEntity;
    }
}
