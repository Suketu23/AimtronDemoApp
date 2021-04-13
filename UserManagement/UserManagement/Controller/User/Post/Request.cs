using System;
using System.ComponentModel.DataAnnotations;
using UserManagement.Database.Models;

namespace UserManagement.Controller.User.Post
{
    /// <summary>
    /// Request model to create new user
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Email address of the user
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the user
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Id of the role
        /// </summary>
        [Required]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Id of the department
        /// </summary>
        [Required]
        public Guid DepartmentId { get; set; }

        public UserDto ToEntityModel()
        {
            return new UserDto(Id, FirstName, LastName, Email, PhoneNumber, RoleId, DepartmentId);
        }
    }
}
