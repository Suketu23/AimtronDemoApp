using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Database.Models;

namespace UserManagement.Database.Entities.Department
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentDto>> IndexAsync();
        Task<DepartmentDto> GetByIdAsync(Guid departmentId);
        Task<Guid> SaveAsync(DepartmentDto departmentDto);
    }
}
