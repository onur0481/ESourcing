using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs.ResponseDTOs;
using ProductService.Domain.Models.ConstantModels;
using System.Net;

namespace ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(T response)
        {
            HttpStatusCode statusCode = HttpStatusCode.OK;

            if (response!.GetType() == typeof(ResponseConstantModel))
            {
                return new ObjectResult(new APIResponseDTO(statusCode, (response as ResponseConstantModel)!))
                {
                    StatusCode = (int)statusCode
                };
            }

            return new ObjectResult(new APIResponseDTO(statusCode, response!))
            {
                StatusCode = (int)statusCode
            };
        }
    }
}
