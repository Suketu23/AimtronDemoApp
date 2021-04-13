
using System;
using UserManagement.Database.Models;

namespace UserManagement.Controller.User.Post
{
    /// <summary>
    /// Response model on successful creation of user
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public Guid Id { get; set; }

        public static Response Create(UserCreationResponse userCreationResponse)
        {
            if (userCreationResponse == null)
            {
                return null;
            }

            return new Response
            {
                Id = userCreationResponse.Id
            };
        }
    }
}
