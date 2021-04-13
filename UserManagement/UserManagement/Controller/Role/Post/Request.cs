
using System;
using UserManagement.Database.Models;

namespace UserManagement.Controller.Role.Post
{
    /// <summary>
    /// Request model to create new role
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Id of the role
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the role
        /// </summary>
        public string Name { get; set; }

        public RoleDto ToEntityModel()
        {
            return new RoleDto(Id, Name);
        }
    }
}
