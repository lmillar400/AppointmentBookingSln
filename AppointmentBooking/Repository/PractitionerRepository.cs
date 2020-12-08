using AppointmentBooking.Models;

namespace AppointmentBooking.Repository
{
    public class PractitionerRepository: GenericRepository<PractitionerModel>, IPractitionerRepository
    {
        private readonly AppDbContext _appDbContext;

        public PractitionerRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
    }
}
