using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZReservation.Models
{
    public class Reservation
    {
        public const int MAX_PASSENGER_COUNT = 5;
        public const int PNR_NUMBER_LENGTH = 6;

        [Key]
        public string PNRNumber { get; set; }

        public string FlightAirlineCode { get; set; }

        public int FlightNumber { get; set; }

        //datatype attribute conveys the semantics of the data
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FlightDate { get; set; }

        public int NumPassengers { get; set; }



        #region Navigation Properties
        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual Flight Flight { get; set; } 
        #endregion
    }
}
