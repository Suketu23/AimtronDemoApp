using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagement.Controller.BaseResponseModel;
using UserManagement.Database.Entities.User;

namespace UserManagement.Controller.LogIn
{
    /// <summary>
    /// Controller to handle login related actions
    /// </summary>
    [Route(BaseRoute + "LogIn")]
    public class LogInController : BaseApiController
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public LogInController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Method to validate user log-in credentials
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("validate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> IsValidLogInAsync([FromBody] Validate.Request request)
        {
            var response = new BaseResponse<bool>();
            var errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(request?.Email))
            {
                errorMessages.Add("Email is required...");
            }
            else if(!new EmailAddressAttribute().IsValid(request.Email))
            {
                errorMessages.Add("Invalid email address...");
            }
            if (string.IsNullOrWhiteSpace(request?.Password))
            {
                errorMessages.Add("Password is required...");
            }

            if (errorMessages.Any())
            {
                response.ErrorMessages = errorMessages;
                return response.ToHttpResponse(HttpStatusCode.BadRequest);
            }

            var isLogInSuccessful = await _userRepository.IsLogInUserExistAsync(request.Email, request.Password);
            if (!isLogInSuccessful)
            {
                errorMessages.Add("Invalid credentials...");
                response.ErrorMessages = errorMessages;
                return response.ToHttpResponse(HttpStatusCode.BadRequest);
            }

            response.Model = true;
            return response.ToHttpResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Log in method
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLogInAsync([FromBody] Post.Request request)
        {
            var response = new BaseResponse<Guid>();
            var errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(request?.Email))
            {
                errorMessages.Add("Email address is required...");
            }
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                errorMessages.Add("Password is required...");
            }
            if (request?.RoleId == default)
            {
                errorMessages.Add("Invalid role...");
            }
            if (request?.DepartmentId == default)
            {
                errorMessages.Add("Invalid department...");
            }

            if (errorMessages.Any())
            {
                response.ErrorMessages = errorMessages;
                return response.ToHttpResponse(HttpStatusCode.BadRequest);
            }

            var logInUserCreationResponse = await _userRepository.CreateLogInUserAsync(request.ToLogInEntity());
            if (logInUserCreationResponse.InvalidDepartment)
            {
                errorMessages.Add("Invalid department...");
            }
            if (logInUserCreationResponse.InvalidRole)
            {
                errorMessages.Add("Invalid role...");
            }

            if (errorMessages.Any())
            {
                response.ErrorMessages = errorMessages;
                return response.ToHttpResponse(HttpStatusCode.BadRequest);
            }

            response.Model = logInUserCreationResponse.Id;
            return response.ToHttpResponse(HttpStatusCode.OK);
        }
    }
}
