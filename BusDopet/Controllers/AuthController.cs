using BusDepot.Models;
using BusDepot1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusDepot.Library;

namespace BusDepot.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> authOptions;
        public AuthController(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions;
        }
        private List<Account> Accounts => new List<Account>
        {
            new Account()
            {
                Id = Guid.Parse("630f1902-d1ce-449b-8317-36575797c1ba"),
                Email = "dispatchar@mail.com",
                Password = "dispatchar",
                Type = EmployeeType.Dispatcher
            },

            new Account()
            {
                Id = Guid.Parse("9221bc6a-a3fd-48d9-ac4b-575c546d741e"),
                Email = "driver@mail.com",
                Password = "driver",
                Type = EmployeeType.Driver
            },

             new Account()
            {
                Id = Guid.Parse("0c608f78-1314-43f0-b9ad-d9321bbefe9b"),
                Email = "doctor@mail.com",
                Password = "doctor",
                Type = EmployeeType.Doctor
            },

              new Account()
            {
                Id = Guid.Parse("ffae3a8f-23e5-4efa-ab12-4f5a86b1684d"),
                Email = "mechanic@mail.com",
                Password = "mechanic",
                Type = EmployeeType.Mechanic
            },
        };

        [Route("login")]
        [HttpPost]

        public IActionResult Login([FromBody]Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);

            if(user != null)
            {
                var token = GenerateJWT(user);

                return Ok(new
                {
                    access_token = token
                });

            }
            return Unauthorized();
        }

        private Account AuthenticateUser(string email, string password)
        {
            return Accounts.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        private string GenerateJWT(Account user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims, expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    } 
}

   
