using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationCaseStudy.Library
{
    public class Flight
    {

        [Key, Column(Order = 0)]
        [StringLength(2, MinimumLength = 2, 
                         ErrorMessage = "A station code should exactly be two characters")]
        public string AirlineCode { get; set; }

        [Key, Column(Order = 1)]
        [Range(1, 9999, 
              ErrorMessage = "A flight number can only be between 1 to 9999")]
        public int Number { get; set; }

        public Station ArrivalStation { get; set; }

        public Station DepartureStation { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        [Range(typeof(TimeSpan), "00:00", "23:59", 
               ErrorMessage ="Schedule time of arrival must be between 00:00 and 23:59.")]
        public TimeSpan ScheduledTimeArrival { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        [Range(typeof(TimeSpan), "00:00", "23:59", 
               ErrorMessage = "Schedule time of departure must be between 00:00 and 23:59.")]
        public TimeSpan ScheduledTimeDeparture { get; set; }


        #region Navigation Properties
        
        //a flight can have 0 to many reservations assigned to it
        public virtual ICollection<Reservation> Reservations { get; set; }
        #endregion

    }
}
