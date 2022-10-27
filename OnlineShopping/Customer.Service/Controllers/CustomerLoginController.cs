using Customer.Service.EntityModels;
using Customer.Service.Repositories;
using Customer.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLoginController : ControllerBase
    {
        private readonly OnlineShoppingContext db;
        private readonly IJWTManagerRepository iJWTMangerRepository;

        public CustomerLoginController(OnlineShoppingContext _db, IJWTManagerRepository _iJWTMangerRepository)
        {
            db = _db;
            iJWTMangerRepository = _iJWTMangerRepository;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            Tokens token = iJWTMangerRepository.AuthenticateLogin(loginViewModel);
            if (token == null)
            {
                return Unauthorized("Unauthorized User");
            }
            
            return Ok(token);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            var token = iJWTMangerRepository.AuthenticateRegister(registerViewModel, true);
            if (token == null)
            {
                return Unauthorized();
            }
            if (token.Token == "EmailId already registered" || token.Token == "LoginId already in Use")
            {
                return Ok(token.Token + "!! Try Again !!");
            }
            return Ok(token);
        }
    }
}
