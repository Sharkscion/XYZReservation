using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationCaseStudy.Library
{
    public class Reservation
    {
        [Key]
        [StringLength(6, ErrorMessage = "PNR number should be exactly 6 alphanumeric characters.")]
        [RegularExpression(@"^[A-Z]+[A-Z0-9]{6}$", ErrorMessage = "PNR Number should only consists of alphanumeric characters with the first character being a letter.")]
        public string PNRNumber { get; set; }

        public string FlightAirlineCode { get; set; }

        public int FlightNumber { get; set; }

        //datatype attribute conveys the semantics of the data
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:mm/dd/yyyy}")]
        public DateTime FlightDate { get; set; }

        [Range(1,5, ErrorMessage = "You can only reserve a maximum of 5 passengers.")]
        public int NumPassengers { get; set; }

        #region Navigation Properties

        public virtual ICollection<Passenger> Passengers { get; set; }

        public virtual Flight Flight { get; set; } 
        #endregion
    }
}
