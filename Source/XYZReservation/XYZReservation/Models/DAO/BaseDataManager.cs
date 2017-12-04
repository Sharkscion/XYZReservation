using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace XYZReservation.Models
{
    public abstract class BaseDataManager<T> where T : class
    {
        //The params part is how you can specify multiple arguments to be converted into an array.
        public virtual IList<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            using(var context = new ReservationDBContext())
            {
                IQueryable<T> set = null;
                foreach (var include in includes)
                {
                    set = context.Set<T>().Include(include);
                }

                return set.ToList();
            }
        }

        public virtual IList<T> GetAll()
        {
            using(var context = new ReservationDBContext())
            {
                return context.Set<T>().ToList();
            }
                
        }

        public virtual IList<T> SearchBy(Expression<Func<T, bool>> predicate)
        {
            using (var context = new ReservationDBContext())
            {
                IQueryable<T> result = context.Set<T>().Where(predicate);
                if (result.Any() == false)
                    return null;
                else
                    return result.ToList();
            }
        }

        public virtual IList<T> SearchByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            using (var context = new ReservationDBContext())
            {
                IQueryable<T> set = null;
                foreach (var include in includes)
                {
                    set = context.Set<T>().Where(predicate).Include(include);
                }

                if (set == null || set.Any() == false)
                {
                    return null;
                }
                else
                {

                    return set.ToList();
                }
            }
        }

        public virtual T SearchObjectByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            using (var context = new ReservationDBContext())
            {
                var set = context.Set<T>().Where(predicate);

                if(set != null)
                {
                    foreach(var include in includes)
                    {
                        set.Include(include);
                    }
                }

                return set.FirstOrDefault();
            }
        }

        public virtual T SearchObjectBy(Expression<Func<T, bool>> predicate)
        {
            using (var context = new ReservationDBContext())
            {
                return context.Set<T>().Where(predicate).FirstOrDefault();
            }
        }

        public abstract void Add(T entity);
        

    }
}
