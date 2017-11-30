using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationCaseStudy.Library
{
    public class Passenger
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "First name cannot be longer than 64 characters.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]*$", ErrorMessage ="First name should only consists of letters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Last name cannot be longer than 64 characters.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]*$", ErrorMessage = "A name should only consists of letters.")]
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
