﻿using FootballManager.ViewModels.Users;

namespace FootballManager.Contracts
{
    public interface IUserService
    {
        (bool registered, string error) Register(RegisterViewModel model);

        string Login(LoginViewModel model);

        string GetUsername(string userId);
    }
}
