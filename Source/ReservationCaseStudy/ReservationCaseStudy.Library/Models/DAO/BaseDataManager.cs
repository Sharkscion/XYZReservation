using System;
using System.Linq;
using System.Linq.Expressions;

namespace ReservationCaseStudy.Library.Models
{
    public abstract class BaseDataManager<T> where T : class
    {

        public virtual IQueryable<T> GetAll()
        {
            using(var context = new ReservationDBContext())
            {
                return context.Set<T>();
            }
                
        }

        public virtual IQueryable<T> SearchBy(Expression<Func<T, bool>> predicate)
        {
            using (var context = new ReservationDBContext())
            {
                return context.Set<T>().Where(predicate);
            }
        }

        public virtual T SearchObjectBy(Expression<Func<T, bool>> predicate)
        {
            using (var context = new ReservationDBContext())
            {
                return context.Set<T>().Where(predicate).FirstOrDefault();
            }
        }

        public virtual void Add(T entity)
        {
            using(var context = new ReservationDBContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

    }
}
