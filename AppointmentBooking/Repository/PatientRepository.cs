using AppointmentBooking.Models;

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
