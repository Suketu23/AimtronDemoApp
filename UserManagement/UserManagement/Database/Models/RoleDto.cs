
using System;

namespace UserManagement.Database.Models
{
    public class RoleDto
    {
        public RoleDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Id of the role
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Name of the role
        /// </summary>
        public string Name { get; private set; }
    }
}
