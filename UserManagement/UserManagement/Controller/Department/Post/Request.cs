
using System;
using UserManagement.Database.Models;

namespace UserManagement.Controller.Department.Post
{
    /// <summary>
    /// Request to add new department
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Id of the department
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the department
        /// </summary>
        public string Name { get; set; }

        public DepartmentDto ToEntityModel()
        {
            return new DepartmentDto(Id, Name);
        }
    }
}
