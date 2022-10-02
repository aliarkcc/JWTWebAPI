using JWTWebAPI.Entity;
using JWTWebAPI.Models;
using JWTWebAPI.Security.JWT;
using JWTWebAPI.UserManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthController(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]UserLoginModel loginModel)
        {
            User user = _userService.AuthenticateUser(loginModel.Email, loginModel.Password);
            if (user is null)
            {
                return BadRequest(new { message = "Email or password is incorred" });
            }
            List<OperationClaim> operationClaims = _userService.GetClaims(user);
            AccessToken token= _tokenHelper.CreateToken(user, operationClaims);
            return Ok(token);
        }
    }
}
