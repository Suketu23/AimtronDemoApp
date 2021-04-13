using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagement.Controller.BaseResponseModel;
using UserManagement.Database.Entities.Role;

namespace UserManagement.Controller.Role
{
    /// <summary>
    /// Controller to handle role related actions
    /// </summary>
    [Route(BaseRoute + "roles")]
    public class RoleController : BaseApiController
    {
        private readonly IRoleRepository _roleRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="roleRepository"></param>
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// Get role details based on id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{roleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAsync([FromRoute] Guid roleId)
        {
            var response = new BaseResponse<Get.Response>();

            var role = await _roleRepository.GetByIdAsync(roleId);
            if (role == null)
            {
                return response.ToHttpResponse(HttpStatusCode.NotFound);
            }

            response.Model =  Get.Response.Create(role);
            return response.ToHttpResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> IndexAsync()
        {
            var response = new BaseResponse<Index.Response>();

            var roles = await _roleRepository.IndexAsync();
            response.Model = Index.Response.Create(roles);

            return response.ToHttpResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Save role in the database
        /// This method will add role if doesn't exist and update is role exist
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SaveAsync([FromBody] Post.Request request)
        {
            var response = new BaseResponse<Post.Response>();
            var errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                errorMessages.Add("Name is required...");
            }

            if (errorMessages.Any())
            {
                response.ErrorMessages = errorMessages;
                return response.ToHttpResponse(HttpStatusCode.BadRequest);
            }

            var roleId = await _roleRepository.SaveAsync(request.ToEntityModel());
            response.Model =  Post.Response.Create(roleId);

            return response.ToHttpResponse(HttpStatusCode.OK);
        }
    }
}
