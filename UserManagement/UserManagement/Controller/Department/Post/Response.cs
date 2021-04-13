
using System;

namespace UserManagement.Controller.Department.Post
{
    /// <summary>
    /// Response model on successful creation of department
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Id of the newly created department
        /// </summary>
        public Guid Id { get; set; }

        public static Response Create(Guid departmentId)
        {
            return new Response
            {
                Id = departmentId
            };
        }
    }
}
