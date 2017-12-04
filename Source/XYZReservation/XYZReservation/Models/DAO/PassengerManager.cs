
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XYZReservation.Models;

namespace XYZReservation.Models
{
    public class PassengerManager : BaseDataManager<Passenger>
    {
        public override void Add(Passenger entity)
        {
            using (var context = new ReservationDBContext())
            {
                context.Set<Passenger>().Add(entity);
                context.SaveChanges();
            }
        }

    }
}
