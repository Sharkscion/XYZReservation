using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationCaseStudy.Library.Models
{
    public class Reservation
    {
        [Key]
        public string PNRNumber { get; set; }

        public string FlightAirlineCode { get; set; }

        public int FlightNumber { get; set; }

        //datatype attribute conveys the semantics of the data
        public DateTime FlightDate { get; set; }

        public int NumPassengers { get; set; }

        #region Navigation Properties

        public virtual ICollection<Passenger> Passengers { get; set; }

        public virtual Flight Flight { get; set; } 
        #endregion
    }
}
