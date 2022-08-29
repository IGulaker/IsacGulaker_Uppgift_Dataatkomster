using IsacGulaker_Uppgift_Dataatkomster.Filters;
using IsacGulaker_Uppgift_Dataatkomster.Models.User;
using IsacGulaker_Uppgift_Dataatkomster.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync(CreateUserModel model)
        {
            return await _userManager.CreateUserAsync(model);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            return await _userManager.ReadUserAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            return new OkObjectResult( await _userManager.ReadAllUsersAsync());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUserAsync(int id, UpdateUserModel model)
        {
            return await _userManager.UpdateUserAsync(id, model);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            return await _userManager.DeleteUserAsync(id);
        }
    }
}
