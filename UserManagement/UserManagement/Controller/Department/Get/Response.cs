using System;
using UserManagement.Database.Models;

namespace UserManagement.Controller.Department.Get
{
    // Response model to get department details
    public class Response
    {
        /// <summary>
        /// Id of the department
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the department
        /// </summary>
        public string Name { get; set; }

        public static Response Create(DepartmentDto departmentDto)
        {
            if (departmentDto == null)
            {
                return null;
            }

            return new Response
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name
            };
        }
    }
}
