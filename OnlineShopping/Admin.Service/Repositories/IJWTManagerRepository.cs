using Admin.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Service.Repositories
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(LoginViewModel users);
    }
}
