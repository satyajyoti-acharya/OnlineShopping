using Customer.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Service.Repositories
{
    public interface IJWTManagerRepository
    {
        Tokens AuthenticateRegister(RegisterViewModel users, bool flag);
        Tokens AuthenticateLogin(LoginViewModel users);
    }
}
