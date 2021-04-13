
using System;

namespace UserManagement.Database.Models
{
    public class UserDto
    {
        public UserDto(Guid id, 
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber, 
            Guid roleId, 
            Guid departmentId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
            DepartmentId = departmentId;
        }

        /// <summary>
        /// Id of the user
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Email address of the user
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Phone number of the user
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Id of the role assigned to user
        /// </summary>
        public Guid RoleId { get; private set; }

        /// <summary>
        /// Id of the department
        /// </summary>
        public Guid DepartmentId { get; private set; }
    }
}
