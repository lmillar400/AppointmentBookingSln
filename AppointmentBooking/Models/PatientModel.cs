using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Models
{
    public class PatientModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Email { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
    }
}
