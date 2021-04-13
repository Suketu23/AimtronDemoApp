
using System;

namespace UserManagement.Controller.Role.Post
{
    /// <summary>
    /// Response model on successful creation of Role
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Id of the role
        /// </summary>
        public Guid Id { get; set; }

        public static Response Create(Guid roleId)
        {
            return new Response
            {
                Id = roleId
            };
        }
    }
}
