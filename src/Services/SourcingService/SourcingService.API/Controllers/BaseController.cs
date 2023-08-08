using Microsoft.AspNetCore.Mvc;
using SourcingService.Application.DTOs.ResponseDTOs;
using SourcingService.Domain.Models.ConstantModels;
using System.Net;

namespace SourcingService.API.Controllers
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
