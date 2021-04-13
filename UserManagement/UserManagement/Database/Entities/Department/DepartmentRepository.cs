using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Database.DatabaseContext;
using UserManagement.Database.Models;

namespace UserManagement.Database.Entities.Department
{
    /// <summary>
    /// Department repository
    /// </summary>
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbContext _dbContext;

        public DepartmentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get department by id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<DepartmentDto> GetByIdAsync(Guid departmentId)
        {
            return await _dbContext.Departments
                .Where(department => department.Id == departmentId)
                .Select(department => new DepartmentDto(department.Id, department.Name))
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get list of all departments`
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DepartmentDto>> IndexAsync()
        {
            return await _dbContext.Departments.Select(department => new DepartmentDto(department.Id, department.Name)).ToListAsync();
        }

        public async Task<Guid> SaveAsync(DepartmentDto departmentDto)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(department => department.Id == departmentDto.Id);
            if (department == null)
            {
                department = new Department(departmentDto.Name);
                _dbContext.Departments.Add(department);
            }
            else
            {
                department.UpdateName(departmentDto.Name);
            }
            
            await _dbContext.SaveChangesAsync();
            return department.Id;
        }
    }
}
