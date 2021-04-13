using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagement.Controller.BaseResponseModel;
using UserManagement.Database.Entities.User;

namespace UserManagement.Controller.User
{
    /// <summary>
    /// Controller to handle user related actions
    /// </summary>
    [Route(BaseRoute + "users")]
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get user details based on id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAsync([FromRoute] Guid userId)
        {
            var response = new BaseResponse<Get.Response>();

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return response.ToHttpResponse(HttpStatusCode.NotFound);
            }

            response.Model = Get.Response.Create(user);

            return response.ToHttpResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> IndexAsync()
        {
            var response = new BaseResponse<Index.Response>();

            var users = await _userRepository.IndexAsync();
            response.Model = Index.Response.Create(users);

            return response.ToHttpResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Save user in the database
        /// This method will add user if doesn't exist and update is user exist
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

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                errorMessages.Add("First name is required...");
            }
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                errorMessages.Add("Last name is required...");
            }
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                errorMessages.Add("Email is required...");
            }
            else if (!new EmailAddressAttribute().IsValid(request.Email))
            {
                errorMessages.Add("Email is invalid...");
            }
            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                errorMessages.Add("Phone number is required...");
            }
            else if (!new PhoneAttribute().IsValid(request.PhoneNumber))
            {
                errorMessages.Add("Phone number is invalid...");
            }
            if (request.RoleId == default)
            {
                errorMessages.Add("Role is invalid...");
            }
            if (request.DepartmentId == default)
            {
                errorMessages.Add("Department is invalid...");
            }

            if (errorMessages.Any())
            {
                response.ErrorMessages = errorMessages;
                return response.ToHttpResponse(HttpStatusCode.BadRequest);
            }

            var userCreationResponse = await _userRepository.SaveAsync(request.ToEntityModel());
            if (userCreationResponse.InvalidDepartment)
            {
                errorMessages.Add("Invalid department...");
            }
            if (userCreationResponse.InvalidRole)
            {
                errorMessages.Add("Invalid role...");
            }

            if (errorMessages.Any())
            {
                response.ErrorMessages = errorMessages;
                return response.ToHttpResponse(HttpStatusCode.BadRequest);
            }

            response.Model = Post.Response.Create(userCreationResponse);
            return response.ToHttpResponse(HttpStatusCode.OK);
        }
    }
}
