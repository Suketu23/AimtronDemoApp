using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Database.Models;

namespace UserManagement.Controller.User.Index
{
    /// <summary>
    /// Response model get all users
    /// </summary>
    public class Response
    {
        /// <summary>
        /// List of users
        /// </summary>
        public IEnumerable<User> Users { get; set; }

        public static Response Create(IEnumerable<UserDto> userDtos)
        {
            if (userDtos == null)
            {
                return null;
            }

            return new Response
            {
                Users = userDtos.Select(u => new User
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    RoleId = u.RoleId,
                    DepartmentId = u.DepartmentId
                })
            };
        }
    }

    /// <summary>
    /// User class
    /// </summary>
    public class User
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
    }
}
