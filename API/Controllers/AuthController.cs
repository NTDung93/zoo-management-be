using API.Helpers;
using API.Models.Authentication;
using API.Models.Dtos;
using API.Repositories;
using API.Token;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ITokenHelper _tokenHelper;

        public AuthController(IEmployeeRepository employeeRepository, IMapper mapper, 
            IConfiguration configuration, ITokenHelper tokenHelper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _configuration = configuration;
            _tokenHelper = tokenHelper;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel account)
        {
            // get the admin account
            var adEmail = _configuration["AdminAccount:Email"];
            var adPassword = _configuration["AdminAccount:Password"];
            var adRole = EmployeeConstraints.ADMIN_ROLE;

            if (account == null)
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid client request!"
                });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (account.Email.Trim().Equals(adEmail) && account.Password.Trim().Equals(adPassword))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, adEmail),
                    new Claim(ClaimTypes.Role, adRole)
                };
                var accessToken = _tokenHelper.GenerateAccessToken(claims);
                return Ok(new AuthenticatedResponse
                {
                    Email = adEmail,
                    FullName = "Admin",
                    Role = adRole,
                    Token = accessToken
                });
            }
            else
            {
                var loginAccount = await _employeeRepository.Authenticate(account);
                if (loginAccount != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, loginAccount.Email),
                        new Claim(ClaimTypes.Role, loginAccount.Role)
                    };
                    var accessToken = _tokenHelper.GenerateAccessToken(claims);
                    if (loginAccount.Role == EmployeeConstraints.TRAINER_ROLE && loginAccount.Area != null)
                    {
                        return Ok(new AuthenticatedResponse
                        {
                            EmployeeId = loginAccount.EmployeeId,
                            Email = loginAccount.Email,
                            FullName = loginAccount.FullName,
                            CitizenId = loginAccount.CitizenId,
                            PhoneNumber = loginAccount.PhoneNumber,
                            Image = loginAccount.Image,
                            Role = loginAccount.Role,
                            AreaId = _mapper.Map<AreaDto>(loginAccount.Area).AreaId,
                            Token = accessToken,
                        });
                    }
                    else
                    {
                        return Ok(new AuthenticatedResponse
                        {
                            EmployeeId = loginAccount.EmployeeId,
                            Email = loginAccount.Email,
                            FullName = loginAccount.FullName,
                            CitizenId = loginAccount.CitizenId,
                            PhoneNumber = loginAccount.PhoneNumber,
                            Image = loginAccount.Image,
                            Role = loginAccount.Role,
                            Token = accessToken,
                        });
                    }
                }
            }
            return NotFound("Account not found!");
        }
    }
}
