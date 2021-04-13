using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Controller
{
    /// <summary>
    /// Base api controller
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    public class BaseApiController : ControllerBase
    {
        /// <summary>
        /// Base route
        /// </summary>
        protected const string BaseRoute = "api/";
    }
}
