using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationCaseStudy.Library.Models
{
    public class Station
    {
        public const int CODE_LENGTH = 3;

        [Key]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; } 

        #region Inverse Properties

        [InverseProperty("ArrivalStation")]
        public virtual ICollection<Flight> ArrivingFlights { get; set; }

        [InverseProperty("DepartureStation")]
        public virtual ICollection<Flight> DepartingFlights { get; set; }

        #endregion

      
    }
}
