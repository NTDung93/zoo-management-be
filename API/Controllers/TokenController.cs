using API.Helpers.Token;
using API.Models.Authen;
using API.Models.Token;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    public class TokenController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;

        public TokenController(IEmployeeRepository employeeRepo, ITokenHelper tokenHelper, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel == null)
                return BadRequest("Invalid client request");

            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;

            var principal = _tokenHelper.GetPrincipalFromExpiredToken(accessToken);
            // error potential 
            // var empName = principal.Identity.Name; // NULL - BUG
            var empEmailClaim = principal.FindFirst(ClaimTypes.Email);
            if (empEmailClaim == null || string.IsNullOrEmpty(empEmailClaim.Value))
                return BadRequest("Invalid client request");

            var empEmail = empEmailClaim.Value;
            var account = await _employeeRepo.GetAccountByEmail(empEmail);

            if (account == null || account.RefreshToken != refreshToken || account.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest("Invalid client request");

            var newAccessToken = _tokenHelper.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenHelper.GenerateRefreshToken();

            if (!await _employeeRepo.AddNewRefreshToken(account, newRefreshToken))
                return UnprocessableEntity("Cannot add refresh token!");

            return Ok(new AuthenticatedResponse
            {
                Employee = _mapper.Map<EmpProfileModel>(account),
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var emailClaim = User.FindFirst(ClaimTypes.Email);
            if (emailClaim == null || string.IsNullOrEmpty(emailClaim.Value))
                return BadRequest("Invalid client request");

            var email = emailClaim.Value;

            var account = await _employeeRepo.GetAccountByEmail(email);
            if (account == null) 
                return BadRequest();
            if (!await _employeeRepo.RevokeRefreshToken(account))
                return BadRequest("An error occurs while processing!");
            return NoContent();
        }
    }
}
