
using System;

namespace UserManagement.Database.Models
{
    public class DepartmentDto
    {
        public DepartmentDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Id of the department
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Name of the department
        /// </summary>
        public string Name { get; }
    }
}
