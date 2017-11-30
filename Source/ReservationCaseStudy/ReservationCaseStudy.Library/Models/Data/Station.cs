using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationCaseStudy.Library
{
    public class Station
    {
        [Key]
        [RegularExpression(@"^[A-Z0-9]*$", ErrorMessage = "A station code should only consists of ")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "A station code should exactly be 64 characters")]
        public string Code { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "A station decription cannot be longer than 64 characters." )]
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]*$", ErrorMessage = "A station description should only consists of alphanumeric characters, space, ', or -.")]
        public string Description { get; set; }


        #region Navigation Properties

        public virtual ICollection<Flight> Flights { get; set; }

        #endregion

        #region Inverse Properties

        [InverseProperty("ArrivalStation")]
        public virtual ICollection<Flight> ArrivingFlights { get; set; }

        [InverseProperty("DepartureStation")]
        public virtual ICollection<Flight> DepartingFlights { get; set; }

        #endregion

        public Station()
        {
        }

      
    }
}
