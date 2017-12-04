using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZReservation.Models
{
    public class Station
    {
        [NotMapped]
        public const int CODE_LENGTH = 3;

        [Key]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; } 
             
    }
}
