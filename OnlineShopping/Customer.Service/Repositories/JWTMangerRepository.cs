using Customer.Service.EntityModels;
using Customer.Service.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.Repositories
{
    public class JWTMangerRepository : IJWTManagerRepository
    {
        Dictionary<string, string> userRecords;

        private readonly IConfiguration configuration;

        private readonly OnlineShoppingContext db;

        public JWTMangerRepository(IConfiguration _configuration, OnlineShoppingContext _db)
        {
            configuration = _configuration;
            db = _db;
        }
        public Tokens AuthenticateRegister(RegisterViewModel users, bool flag)
        {
            if (flag)
            {
                if (db.CustomerLogins.Any(x => x.Email == users.Email))
                {
                    Tokens tokens = new Tokens();
                    tokens.Token = "EmailId already registered";
                    return tokens;
                }

                if (db.CustomerLogins.Any(x => x.LoginId == users.LoginId))
                {
                    Tokens tokens = new Tokens();
                    tokens.Token = "LoginId already in Use";
                    return tokens;
                }

                CustomerLogin loginUser = new CustomerLogin();
                loginUser.Email = users.Email;
                loginUser.Fname = users.Fname;
                loginUser.Lname = users.Lname;
                loginUser.LoginId = users.LoginId;
                loginUser.Password = users.Password;
                loginUser.UserRole = "Customer";
                loginUser.ContactNo = users.ContactNo;
                db.CustomerLogins.Add(loginUser);
                db.SaveChanges();
            }

            userRecords = db.CustomerLogins.Where(x => x.UserRole == "Customer").ToList().ToDictionary(x => x.LoginId, x => x.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if (!userRecords.Any(x => x.Key == users.LoginId && x.Value == users.Password))
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,users.LoginId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }


        public Tokens AuthenticateLogin(LoginViewModel users)
        {

            userRecords = db.CustomerLogins.Where(x => x.UserRole == "Customer").ToList().ToDictionary(x => x.LoginId, x => x.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if (!userRecords.Any(x => x.Key == users.LoginId && x.Value == users.Password))
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,users.LoginId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
