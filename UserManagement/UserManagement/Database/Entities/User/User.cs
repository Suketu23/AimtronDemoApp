using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Database.Entities.User
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="email"></param>
        /// <param name="roleId"></param>
        /// <param name="departmentId"></param>
        /// <param name="password"></param>
        public User(string email, Guid roleId, Guid departmentId, string password = "password_123")
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            else if (!new EmailAddressAttribute().IsValid(email))
            {
                throw new ArgumentException("Invalid email address...");
            }
            if (roleId == default)
            {
                throw new ArgumentException("Invalid role...");
            }
            if (departmentId == default)
            {
                throw new ArgumentException("Invalid department...");
            }

            Id = Guid.NewGuid();
            Password = password;
            Email = email;
            RoleId = roleId;
            DepartmentId = departmentId;
        }

        /// <summary>
        /// Update user details
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="roleId"></param>
        /// <param name="departmentId"></param>
        public void Update(string firstName, string lastName, string phoneNumber, Guid roleId, Guid departmentId)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }
            else if (!new PhoneAttribute().IsValid(phoneNumber))
            {
                throw new ArgumentException("Invalid phone number...");
            }
            if (roleId == default)
            {
                throw new ArgumentException("Invalid role...");
            }
            if (departmentId == default)
            {
                throw new ArgumentException("Invalid department...");
            }

            FirstName = firstName;
            LastName = lastName;
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
        /// Id of the Role
        /// </summary>
        [ForeignKey("RoleId")]
        public Guid RoleId { get; private set; }
        public virtual Role.Role Role { get; set; }

        /// <summary>
        /// Id of the Department
        /// </summary>
        [ForeignKey("DepartmentId")]
        public Guid DepartmentId { get; private set; }
        public virtual Department.Department Department { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; private set; }
    }
}
