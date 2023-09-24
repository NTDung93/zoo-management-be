using API.Helpers;
using API.Models.Dtos;
using API.Models.Entities;
using API.Models.Login;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{

    public class LoginController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        //private readonly BuggyController _buggy;
        private readonly IConfiguration _config;

        public LoginController(
            IEmployeeRepository employeeRepository, IMapper mapper, 
            IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _config = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        public async Task<ActionResult<SignInResponse>> Login(AccountLogin account)
        {
            // get the admin account saved at appsettings.json
            var adEmail = _config["AdminAccount:Email"];
            var adPassword = _config["AdminAccount:Password"];
            var adRole = _config["AdminAccount:Role"];
            
            if (account == null)
                return BadRequest("Account must not be empty!");
            // authenticate the admin
            if (account.Email.Trim().ToLower().Equals(adEmail.Trim().ToLower()) 
                && account.Password.ToLower().Trim().Equals(adPassword.Trim().ToLower()))
            {
                var adAccount = _mapper.Map<AdminAccount>(account);
                adAccount.Role = adRole;
                var token = GenerateToken(adAccount);
                return Ok(new SignInResponse()
                {
                    AdminAccount = adAccount,
                    AccessToken = token
                });
            }
            var loginAccount = await _employeeRepository.Authenticate(account);
            if (loginAccount != null)
            {
                var token = GenerateToken(loginAccount);
                return Ok(new SignInResponse()
                {
                    Employee = loginAccount,
                    AccessToken = token
                });
            }
            return NotFound("Account does not exist!");     
        }

        private string GenerateToken(EmployeeDto employeeDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, employeeDto.Id),
                new Claim(ClaimTypes.Role, employeeDto.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateToken(AdminAccount admin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Email),
                new Claim(ClaimTypes.Role, admin.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
