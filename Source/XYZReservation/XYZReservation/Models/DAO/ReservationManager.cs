
using System;
using System.Data.Entity;
using System.Linq;

namespace XYZReservation.Models
{
    public class ReservationManager : BaseDataManager<Reservation>
    {
        public override void Add(Reservation entity)
        {
            using(var context = new ReservationDBContext())
            {
                foreach(var passenger in entity.Passengers)
                {
                    if (context.Passengers.Where( p => p.FirstName == passenger.FirstName &&
                                                       p.LastName == passenger.LastName &&
                                                       p.Birthday == passenger.Birthday) != null)
                    {
                        context.Entry(passenger).State = EntityState.Added;
                    }
                }

                context.Set<Reservation>().Add(entity);
                context.SaveChanges();
            }
        }
    }
}
