using RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterRequestModel requestModel);
        UserModel Authenticate(LoginRequestModel requestModel);
    }
}
