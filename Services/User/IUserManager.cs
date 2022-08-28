using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Services.User
{
    public interface IUserManager
    {
        public Task<IActionResult> CreateUserAsync(CreateUserModel model);
        public Task<IActionResult> ReadUserAsync(int id);
        public Task<IEnumerable<RequestUserModel>> ReadAllUsersAsync();
        public Task<IActionResult> UpdateUserAsync(int id, UpdateUserModel model);
        public Task<IActionResult> DeleteUserAsync(int id);

        public void CreateUserPassword(UserEntity userEntity, string newPassword);
        public Task<IActionResult> CompareUserPasswordAsync();

        public Task<UserEntity> GetUserAsync(int id);
    }
}
