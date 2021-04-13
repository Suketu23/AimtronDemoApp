using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Database.Models;

namespace UserManagement.Database.Entities.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> IndexAsync();
        Task<UserDto> GetByIdAsync(Guid userId);
        Task<UserCreationResponse> SaveAsync(UserDto userDto);
        Task<UserCreationResponse> CreateLogInUserAsync(UserLogInDto userLogInDto);
        Task<bool> IsLogInUserExistAsync(string email, string password);
    }
}
