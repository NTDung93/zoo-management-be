using API.Helpers;
using API.Helpers.Token;
using API.Models.Authen;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly IConfiguration _config;

        public AuthController(IEmployeeRepository employeeRepo, IMapper mapper, 
            ITokenHelper tokenHelper, 
            IConfiguration config)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _config = config;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel account)
        {
            // get the admin account
            var adEmail = _config["AdminAccount:Email"];
            var adPassword = _config["AdminAccount:Password"];
            var adRole = EmpParams.ADMIN_ROLE;
            
            if (account == null)
                return BadRequest("Invalid client request");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (account.Email.Trim().Equals(adEmail) && account.Password.Trim().Equals(adPassword))
            {
                AdminAuthen admin = new AdminAuthen
                {
                    Email = adEmail,
                    Password = adPassword,
                    Role = adRole
                };
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, adEmail),
                    new Claim(ClaimTypes.Role, EmpParams.ADMIN_ROLE)
                };
                var accessToken = _tokenHelper.GenerateAccessToken_V2(claims); 
                return Ok(new AuthenticatedResponse
                {
                    Admin = admin,
                    Token = accessToken
                });
            }
            else
            {
                var loginAccount = await _employeeRepo.Authenticate(account);
                if (loginAccount != null)
                {
                    var empProfile = _mapper.Map<EmpProfileModel>(loginAccount);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, empProfile.Email),
                        new Claim(ClaimTypes.Role, empProfile.Role)
                    };
                    var accessToken = _tokenHelper.GenerateAccessToken(claims);
                    var refreshToken = _tokenHelper.GenerateRefreshToken();

                    if (!await _employeeRepo.AddRefreshToken(empProfile, refreshToken))
                        return UnprocessableEntity("Cannot add refresh token!");

                    return Ok(new AuthenticatedResponse
                    {
                        Employee = empProfile,
                        Token = accessToken,
                        RefreshToken = refreshToken
                    });
                }
            }
            return NotFound("Account not found");
        }
    }
}
