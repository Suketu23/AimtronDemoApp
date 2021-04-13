using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagement.Controller.BaseResponseModel;
using UserManagement.Database.Entities.Department;

namespace UserManagement.Controller.Department
{
    /// <summary>
    /// Controller to handle department related actions
    /// </summary>
    [Route(BaseRoute + "departments")]
    public class DepartmentController : BaseApiController
    {
        private readonly IDepartmentRepository _departmentRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="departmentRepository"></param>
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Get department details based on id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{departmentId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAsync([FromRoute] Guid departmentId)
        {
            var response = new BaseResponse<Get.Response>();

            var department = await _departmentRepository.GetByIdAsync(departmentId);
            response.Model = Get.Response.Create(department);

            if (department == null)
            {
                return response.ToHttpResponse(HttpStatusCode.NotFound);
            }

            return response.ToHttpResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Get all departments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> IndexAsync()
        {
            var response = new BaseResponse<Index.Response>();

            var departments = await _departmentRepository.IndexAsync();
            response.Model = Index.Response.Create(departments);

            return response.ToHttpResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Save department in the database
        /// This method will add department if doesn't exist and update is department exist
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

            var departmentId = await _departmentRepository.SaveAsync(request.ToEntityModel());
            response.Model =  Post.Response.Create(departmentId);

            return response.ToHttpResponse(HttpStatusCode.OK);
        }
    }
}
