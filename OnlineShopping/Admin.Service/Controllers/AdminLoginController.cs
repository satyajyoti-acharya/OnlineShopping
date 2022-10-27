using Admin.Service.EntityModels;
using Admin.Service.Repositories;
using Admin.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly OnlineShoppingContext db;
        private readonly IJWTManagerRepository iJWTMangerRepository;

        public AdminLoginController(OnlineShoppingContext _db, IJWTManagerRepository _iJWTMangerRepository)
        {
            db = _db;
            iJWTMangerRepository = _iJWTMangerRepository;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var token = iJWTMangerRepository.Authenticate(loginViewModel);
            if (token == null)
            {
                return Unauthorized("Unauthorized User");
            }
            return Ok(token);
        }

    }
}
