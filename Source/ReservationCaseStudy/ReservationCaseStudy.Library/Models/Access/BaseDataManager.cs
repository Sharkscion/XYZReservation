using System;
using System.Linq;
using System.Linq.Expressions;

namespace ReservationCaseStudy.Library
{
    public abstract class BaseDataManager<T> : IDisposable where T : class
    {
        private ReservationDBContext _DbContext = new ReservationDBContext();

        public ReservationDBContext DBContext
        {
            get
            {
                return _DbContext;
            }

            set
            {
                _DbContext = value;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return _DbContext.Set<T>();
        }

        public virtual IQueryable<T> SearchBy(Expression<Func<T, bool>> predicate)
        {
            return _DbContext.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            _DbContext.Set<T>().Add(entity);
        }

        public void Dispose()
        {
            _DbContext.SaveChanges();
        }
    }
}
