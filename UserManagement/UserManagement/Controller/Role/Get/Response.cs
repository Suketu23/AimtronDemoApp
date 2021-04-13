using System;
using UserManagement.Database.Models;

namespace UserManagement.Controller.Role.Get
{
    public class Response
    {
        /// <summary>
        /// Id of the role
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the role
        /// </summary>
        public string Name { get; set; }

        public static Response Create(RoleDto roleDto)
        {
            if (roleDto == null)
            {
                return null;
            }

            return new Response
            {
                Id = roleDto.Id,
                Name = roleDto.Name
            };
        }
    }
}
