
namespace UserManagement.Controller.LogIn.Validate
{
    /// <summary>
    /// Request model to validate log-in credentials
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Email address of the user
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }
    }
}
