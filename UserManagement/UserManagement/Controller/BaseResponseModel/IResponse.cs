using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace UserManagement.Controller.BaseResponseModel
{
    /// <summary>
    /// IResponse interface
    /// </summary>
    public interface IResponse<TModel>
    {
        /// <summary>
        /// Error Message
        /// </summary>
        IEnumerable<string> ErrorMessages { get; set; }

        /// <summary>
        /// Model
        /// </summary>
        TModel Model { get; set; }
    }

    /// <summary>
    /// Response model
    /// </summary>
    public class BaseResponse<TModel> : IResponse<TModel>
    {
        /// <summary>
        /// Error message
        /// </summary>
        public IEnumerable<string> ErrorMessages { get; set; }

        /// <summary>
        /// Model
        /// </summary>
        public TModel Model { get; set; }
    }

    /// <summary>
    /// Response extension class
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// To http response extension method
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static IActionResult ToHttpResponse<TModel>(this IResponse<TModel> response, HttpStatusCode httpStatusCode)
        {
            var status = httpStatusCode;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}
