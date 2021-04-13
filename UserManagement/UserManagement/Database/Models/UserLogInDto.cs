
using System;

namespace UserManagement.Database.Models
{
    /// <summary>
    /// User log in model
    /// </summary>
    public class UserLogInDto
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <param name="departmentId"></param>
        /// <param name=""></param>
        public UserLogInDto(string email, string password, Guid roleId, Guid departmentId)
        {
            Email = email;
            Password = password;
            RoleId = roleId;
            DepartmentId = departmentId;
        }

        /// <summary>
        /// Email address of the user
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// Id of the role for user
        /// </summary>
        public Guid RoleId { get; private set; }
        /// <summary>
        /// Id of the department for the user
        /// </summary>
        public Guid DepartmentId { get; private set; }
    }
}
