using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Database.Models;

namespace UserManagement.Controller.Role.Index
{
    /// <summary>
    /// Response model to get list of all available roles
    /// </summary>
    public class Response
    {
        /// <summary>
        /// List of departments
        /// </summary>
        public IEnumerable<Role> Roles { get; set; }

        public static Response Create(IEnumerable<RoleDto> roleDtos)
        {
            if (roleDtos == null)
            {
                return new Response { Roles = new List<Role>() };
            }

            return new Response
            {
                Roles = roleDtos.Select(r => new Role
                {
                    Id = r.Id,
                    Name = r.Name
                })
            };
        }
    }

    /// <summary>
    /// Role class
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Id of the role
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the role
        /// </summary>
        public string Name { get; set; }
    }
}
