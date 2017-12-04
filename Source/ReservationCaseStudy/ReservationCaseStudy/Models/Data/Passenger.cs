using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationCaseStudy.Models
{
    public class Passenger
    {
        [NotMapped]
        public const int MAX_NAME_LENGTH = 64;
        public int Id { get; set; }

        [Required]
        [StringLength(MAX_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(MAX_NAME_LENGTH)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        #region Calculated Properties

        public int Age
        {

            get
            {

                DateTime now = DateTime.Today;
                var age = now.Year - Birthday.Year;

                if (now < Birthday.AddYears(age))
                    age--;

                return age;
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        #endregion

        #region Navigation Properties

        public virtual ICollection<Reservation> Reservations { get; set; }

        #endregion
    }
}
