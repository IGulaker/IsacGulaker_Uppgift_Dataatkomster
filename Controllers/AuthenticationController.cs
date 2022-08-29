using IsacGulaker_Uppgift_Dataatkomster.Data;
using IsacGulaker_Uppgift_Dataatkomster.Filters;
using IsacGulaker_Uppgift_Dataatkomster.Models.Forms;
using IsacGulaker_Uppgift_Dataatkomster.Models.User;
using IsacGulaker_Uppgift_Dataatkomster.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IsacGulaker_Uppgift_Dataatkomster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserManager userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(CreateUserModel form)
        {
            IActionResult result = await _userManager.CreateUserAsync(form);
            return result as OkObjectResult == null ? result : result as OkObjectResult;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInForm form)
        {
            if (string.IsNullOrEmpty(form.Email) | string.IsNullOrEmpty(form.Password))
                return new BadRequestObjectResult("Email and password must be provided");

            var userEntity = await _userManager.GetUserAsync(form.Email);
            if (userEntity == null)
                return new BadRequestObjectResult("Incorrect email or password");

            if (!_userManager.CompareUserPassword(userEntity, form.Password))
                return new BadRequestObjectResult("Incorrect email or password");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEntity.EmailAddress),
                    new Claim(ClaimTypes.Email, userEntity.EmailAddress),
                    new Claim("UserId", userEntity.Id.ToString()),
                    new Claim("ApiAccessKey", _configuration.GetValue<string>("ApiKeys:ApiAccessKey"))
                }),

                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("ApiKeys:JWTKey"))),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return new OkObjectResult(accessToken);
        }
    }
}
