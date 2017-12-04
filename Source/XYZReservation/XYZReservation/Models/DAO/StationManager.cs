
using System;
using XYZReservation.Models;

namespace XYZReservation.Models
{
    public class StationManager : BaseDataManager<Station>
    {
        public override void Add(Station entity)
        {
            using(var context = new ReservationDBContext())
            {
                context.Set<Station>().Add(entity);
                context.SaveChanges();
            }
        }
    }
}
