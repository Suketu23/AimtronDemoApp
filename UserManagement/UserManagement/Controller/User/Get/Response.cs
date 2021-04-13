
using System;
using UserManagement.Database.Models;

namespace UserManagement.Controller.User.Get
{
    /// <summary>
    /// Response model to get user details
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email address of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the user
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Id of the role
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Id of the department
        /// </summary>
        public Guid DepartmentId { get; set; }

        public static Response Create(UserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            return new Response
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                RoleId = userDto.RoleId,
                DepartmentId = userDto.DepartmentId
            };
        }
    }
}
