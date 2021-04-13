using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Database.Models;

namespace UserManagement.Database.Entities.Role
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleDto>> IndexAsync();
        Task<RoleDto> GetByIdAsync(Guid roledId);
        Task<Guid> SaveAsync(RoleDto roleDto);
    }
}
