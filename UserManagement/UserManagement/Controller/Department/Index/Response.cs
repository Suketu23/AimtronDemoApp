using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Database.Models;

namespace UserManagement.Controller.Department.Index
{
    /// <summary>
    /// Response model to get list of all available departments
    /// </summary>
    public class Response
    {
        /// <summary>
        /// List of departments
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }

        public static Response Create(IEnumerable<DepartmentDto> departmentDtos)
        {
            if (departmentDtos == null)
            {
                return new Response { Departments = new List<Department>() };
            }

            return new Response
            {
                Departments = departmentDtos.Select(d => new Department
                {
                    Id = d.Id,
                    Name = d.Name
                })
            };
        }
    }

    /// <summary>
    /// Department class
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Id of the department
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// name of the department
        /// </summary>
        public string Name { get; set; }
    }
}
