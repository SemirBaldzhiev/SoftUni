using FootballManager.ViewModels.Users;
using System.Collections.Generic;

namespace FootballManager.Contracts
{
    public interface IUserService
    {
        List<string> Register(RegisterViewModel model);

        string Login(LoginViewModel model);
    }
}
