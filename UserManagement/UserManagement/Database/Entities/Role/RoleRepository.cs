using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Database.DatabaseContext;
using UserManagement.Database.Models;

namespace UserManagement.Database.Entities.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _dbContext;

        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get role by id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<RoleDto> GetByIdAsync(Guid roleId)
        {
            return await _dbContext.Roles
                .Where(role => role.Id == roleId)
                .Select(role => new RoleDto(role.Id, role.Name))
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get list of all roles
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RoleDto>> IndexAsync()
        {
            return await _dbContext.Roles.Select(role => new RoleDto(role.Id, role.Name)).ToListAsync();
        }

        /// <summary>
        /// Save role
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        public async Task<Guid> SaveAsync(RoleDto roleDto)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(role => role.Id == roleDto.Id);
            if (role == null)
            {
                role = new Role(roleDto.Name);
                _dbContext.Roles.Add(role);
            }
            else
            {
                role.UpdateName(roleDto.Name); 
            }

            await _dbContext.SaveChangesAsync();
            return role.Id;
        }
    }
}
