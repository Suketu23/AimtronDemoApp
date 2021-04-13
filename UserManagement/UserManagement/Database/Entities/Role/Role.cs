using System;

namespace UserManagement.Database.Entities.Role
{
    /// <summary>
    /// Role entity
    /// </summary>
    public class Role
    {
        public Role(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Id = Guid.NewGuid();
            Name = name;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Id of the role
        /// </summary>
        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}
