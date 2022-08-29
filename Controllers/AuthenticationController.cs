using IsacGulaker_Uppgift_Dataatkomster.Data;
using IsacGulaker_Uppgift_Dataatkomster.Filters;
using IsacGulaker_Uppgift_Dataatkomster.Models.Forms;
using IsacGulaker_Uppgift_Dataatkomster.Models.User;
using IsacGulaker_Uppgift_Dataatkomster.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsacGulaker_Uppgift_Dataatkomster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
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

        /*[HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInForm form)
        {
            if (string.IsNullOrEmpty(form.Email) | string.IsNullOrEmpty(form.Password))
                return new BadRequestObjectResult("Email and password must be provided");

            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email == form.Email);
            if (userEntity == null)
                return new BadRequestObjectResult("Incorrect email or password");

            if (!userEntity.CompareSecurePassword(form.Password))
                return new BadRequestObjectResult("Incorrect email or password");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEntity.Email),
                    new Claim(ClaimTypes.Email, userEntity.Email),
                    new Claim("UserId", userEntity.Id.ToString()),
                    new Claim("ApiKey", _configuration.GetValue<string>("ApiKey"))
                }),

                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey"))),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return new OkObjectResult(accessToken);
        }*/
    }
}
