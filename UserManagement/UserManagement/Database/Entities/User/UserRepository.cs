using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Database.DatabaseContext;
using UserManagement.Database.Models;

namespace UserManagement.Database.Entities.User
{
    /// <summary>
    /// User repository to modify user entities
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get user details based on id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDto> GetByIdAsync(Guid userId)
        {
            return await _dbContext.Users
                        .Where(user => user.Id == userId)
                        .Select(user => new UserDto(userId, user.FirstName, user.LastName, user.Email, user.PhoneNumber, user.RoleId, user.DepartmentId))
                        .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserDto>> IndexAsync()
        {
            return await _dbContext.Users
                .Select(user => new UserDto(user.Id, user.FirstName, user.LastName, user.Email, user.PhoneNumber, user.RoleId, user.DepartmentId))
                .ToListAsync();
        }

        /// <summary>
        /// Create log in user in the database
        /// </summary>
        /// <param name="userLogInDto"></param>
        /// <returns></returns>
        public async Task<UserCreationResponse> CreateLogInUserAsync(UserLogInDto userLogInDto)
        {
            if (!await _dbContext.Departments.AnyAsync(d => d.Id == userLogInDto.DepartmentId))
            {
                return new UserCreationResponse(default, invalidDepartment: true);
            }

            if (!await _dbContext.Roles.AnyAsync(r => r.Id == userLogInDto.RoleId))
            {
                return new UserCreationResponse(default, invalidRole: true);
            }

            var logInUser = new User(userLogInDto.Email, userLogInDto.RoleId, userLogInDto.DepartmentId, userLogInDto.Password);
            _dbContext.Users.Add(logInUser);
            await _dbContext.SaveChangesAsync();

            return new UserCreationResponse(logInUser.Id);
        }

        /// <summary>
        /// Method to check log-in user existence
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> IsLogInUserExistAsync(string email, string password)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email && u.Password == password);
        }

        /// <summary>
        /// Save user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public async Task<UserCreationResponse> SaveAsync(UserDto userDto)
        {
            if (!await _dbContext.Departments.AnyAsync(d => d.Id == userDto.DepartmentId))
            {
                return new UserCreationResponse(default, invalidDepartment: true);
            }

            if (!await _dbContext.Roles.AnyAsync(r => r.Id == userDto.RoleId))
            {
                return new UserCreationResponse(default, invalidRole: true);
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userDto.Id);
            if (user == null)
            {
                user = new User(userDto.Email, userDto.RoleId, userDto.DepartmentId);
                _dbContext.Users.Add(user);
            }

            user.Update(userDto.FirstName, userDto.LastName, userDto.PhoneNumber, userDto.RoleId, userDto.DepartmentId);

            await _dbContext.SaveChangesAsync();
            return new UserCreationResponse(user.Id);
        }
    }
}
