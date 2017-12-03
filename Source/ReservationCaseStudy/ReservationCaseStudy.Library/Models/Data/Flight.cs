using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationCaseStudy.Models
{
    public class Flight
    {
        [NotMapped]
        public const int AIRLINE_CODE_LENGTH = 2;

        [NotMapped]
        public const int MAX_FLIGHT_NUMBER = 9999;

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AirlineCode { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; }

        public string ArrivalStationCode { get; set; }
        
        public string DepartureStationCode { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan ScheduledTimeArrival { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan ScheduledTimeDeparture { get; set; }

        #region Navigation Properties
        
        //a flight can have 0 to many reservations assigned to it
        public virtual ICollection<Reservation> Reservations { get; set; }

        [ForeignKey("ArrivalStationCode")]
        public Station ArrivalStation { get; set; }

        [ForeignKey("DepartureStationCode")]
        public Station DepartureStation { get; set; }
        #endregion



    }
}
