using System;

namespace UserManagement.Database.Models
{
    /// <summary>
    /// User response class
    /// </summary>
    public class UserCreationResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="invalidDepartment"></param>
        /// <param name="invalidRole"></param>
        public UserCreationResponse(Guid id, bool invalidDepartment = false, bool invalidRole = false)
        {
            Id = id;
            InvalidDepartment = invalidDepartment;
            InvalidRole = invalidRole;
        }

        public Guid Id { get; private set; }
        public bool InvalidDepartment { get; private set; }
        public bool InvalidRole { get; private set; }
    }
}
