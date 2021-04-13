
using System;
using UserManagement.Database.Models;

namespace UserManagement.Controller.LogIn.Post
{
    /// <summary>
    /// Request model to login with email and password
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Email address to login
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password to loging
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Id of the role
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Id of the department
        /// </summary>
        public Guid DepartmentId { get; set; }

        public UserLogInDto ToLogInEntity()
        {
            return new UserLogInDto(Email, Password, RoleId, DepartmentId);
        }
    }
}
