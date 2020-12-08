using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Models
{
    public class AppointmentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int PractitionerId { get; set; }
        [Required]
        public DateTime AppointmentDateTime { get; set; }
    }
}
