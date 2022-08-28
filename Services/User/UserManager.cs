using AutoMapper;
using IsacGulaker_Uppgift_Dataatkomster.Data;
using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.User;
using IsacGulaker_Uppgift_Dataatkomster.Services.Address;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace IsacGulaker_Uppgift_Dataatkomster.Services.User
{
    public class UserManager : IUserManager
    {
        private readonly DataContext _context;
        private readonly IAddressManager _addressManager;
        private readonly IMapper _mapper;

        public UserManager(DataContext context, IMapper mapper, IAddressManager addressManager)
        {
            _context = context;
            _mapper = mapper;
            _addressManager = addressManager;
        }

        #region CRUDLogic

        public async Task<IActionResult> CreateUserAsync(CreateUserModel model)
        {
            UserEntity userEntity = await GetUserAsync(model);
            if (userEntity == null)
            {
                await _addressManager.CreateAddressAsync(model.NewUserAddress);

                userEntity = _mapper.Map<UserEntity>(model);
                userEntity.Address = await _addressManager.GetAddressAsync(model.NewUserAddress);
                CreateUserPassword(userEntity, model.NewUserPassword);

                await _context.Users.AddAsync(userEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult($"A user profile for {userEntity.FirstName} {userEntity.LastName} with email {userEntity.EmailAddress} has been created");
            }

            return new ConflictObjectResult("User already exists");
        }

        public async Task<IActionResult> ReadUserAsync(int id)
        {
            UserEntity userEntity = await GetUserAsync(id);
            if (userEntity != null)
            {
                RequestUserModel requestUserModel = _mapper.Map<RequestUserModel>(userEntity);

                return new OkObjectResult(requestUserModel);
            }

            return new BadRequestObjectResult("Could not find user by given id");
        }

        public async Task<IEnumerable<RequestUserModel>> ReadAllUsersAsync()
        {
            List<UserEntity> userEntities = await _context.Users.Include(x => x.Address).ToListAsync();
            List<RequestUserModel> requestUserModels = new List<RequestUserModel>();

            for (int i = 0; i < userEntities.Count; i++)
                requestUserModels.Add(_mapper.Map<RequestUserModel>(userEntities[i]));

            return requestUserModels;
        }

        public async Task<IActionResult> UpdateUserAsync(int id, UpdateUserModel model)
        {
            UserEntity userEntity = await GetUserAsync(id);
            if (userEntity != null)
            {
                userEntity.FirstName = model.NewUserFirstName;
                userEntity.LastName = model.NewUserLastName;
                userEntity.EmailAddress = model.NewUserEmailAddress;
                userEntity.PhoneNumber = model.NewUserPhoneNumber;
                userEntity.AlternativePhoneNumber = model.NewUserAlternativePhoneNumber;
                await _addressManager.CreateAddressAsync(model.NewUserAddress);
                userEntity.Address = await _addressManager.GetAddressAsync(model.NewUserAddress);

                _context.Entry(userEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new OkObjectResult("User has been modified");
            }

            return new BadRequestObjectResult("Could not find user by given id");
        }

        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            UserEntity userEntity = await GetUserAsync(id);
            string userName;
            if (userEntity != null)
            {
                userName = userEntity.FirstName + " " + userEntity.LastName;

                _context.Users.Remove(userEntity);

                await _context.SaveChangesAsync();

                return new OkObjectResult($"User {userName} has been removed from the database");
            }

            return new BadRequestObjectResult("Could not find an artist to remove by given id");
        }

        #endregion

        public async Task<UserEntity> GetUserAsync(int id)
        {
            return await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserEntity> GetUserAsync(CreateUserModel model)
        {
            return await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.EmailAddress == model.NewUserEmailAddress);
        }

        #region PasswordLogic

        public void CreateUserPassword(UserEntity userEntity, string newPassword)
        {
            using (HMACSHA512 hmac = new())
            {
                userEntity.PasswordSalt = hmac.Key;
                userEntity.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(newPassword));
            }
        }

        public Task<IActionResult> CompareUserPasswordAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
