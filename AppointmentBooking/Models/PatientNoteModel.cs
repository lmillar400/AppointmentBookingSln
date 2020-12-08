using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Models
{
    public class PatientNoteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int PractitionerId { get; set; }
        [Required]
        public string NoteDescription { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
