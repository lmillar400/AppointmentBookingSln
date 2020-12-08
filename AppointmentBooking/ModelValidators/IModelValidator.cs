using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.ModelValidators
{
    public interface IModelValidator<T> where T : class
    {
        bool Validate(T model);
    }
}
