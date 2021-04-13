using System;

namespace UserManagement.Database.Entities.Department
{
    /// <summary>
    /// Department entity
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Department(string name)
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
        /// Id of the department
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the department
        /// </summary>
        public string Name { get; private set; }
    }
}
