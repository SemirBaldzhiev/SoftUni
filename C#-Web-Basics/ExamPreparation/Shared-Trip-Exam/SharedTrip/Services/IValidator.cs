using SharedTrip.Dtos.Trips;
using SharedTrip.Dtos.Users;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateTrip(AddTripFormModel model);

    }
}
