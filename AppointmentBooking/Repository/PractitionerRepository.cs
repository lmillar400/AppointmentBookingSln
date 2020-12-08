using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
