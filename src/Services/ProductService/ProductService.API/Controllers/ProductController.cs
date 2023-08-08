using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.CQRS.ProductContextCQRSs.CommandCreateProduct;
using ProductService.Application.CQRS.ProductContextCQRSs.CommandDeleteProduct;
using ProductService.Application.CQRS.ProductContextCQRSs.CommandUpdateProduct;
using ProductService.Application.CQRS.ProductContextCQRSs.QueryGetByIDProduct;
using ProductService.Application.CQRS.ProductContextCQRSs.QueryGetProducts;

namespace ProductService.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
            GetProductsQueryResponse queryResponse = await _mediator.Send(new GetProductsQueryRequest());

            if (queryResponse.Response != null) return CreateActionResult(queryResponse.Response);

            return CreateActionResult(queryResponse.Products);
        }

        [HttpGet]
        [Route("getProduct/{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            GetByIDProductQueryResponse queryResponse = await _mediator.Send(new GetByIDProductQueryRequest(id));

            if (queryResponse.Response != null) return CreateActionResult(queryResponse.Response);

            return CreateActionResult(queryResponse.Product);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse commandResponse = await _mediator.Send(request);

            return CreateActionResult(commandResponse.Response);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse commandResponse = await _mediator.Send(request);

            return CreateActionResult(commandResponse.Response);
        }

        [HttpDelete]
        [Route("deleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            DeleteProductCommandResponse commandResponse = await _mediator.Send(new DeleteProductCommandRequest(id));

            return CreateActionResult(commandResponse.Response);
        }

    }
}
