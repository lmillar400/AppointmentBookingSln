using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Repository
{
    public class PatientRepository: GenericRepository<PatientModel>, IPatientRepository
    {
        private readonly AppDbContext _appDbContext;

        public PatientRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
    }
}
