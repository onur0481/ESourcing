using MediatR;
using Microsoft.AspNetCore.Mvc;
using SourcingService.Application.CQRS.AuctionContextCQRSs.CommandCompleteAuction;
using SourcingService.Application.CQRS.AuctionContextCQRSs.CommandCreateAuction;
using SourcingService.Application.CQRS.AuctionContextCQRSs.CommandDeleteAuction;
using SourcingService.Application.CQRS.AuctionContextCQRSs.CommandUpdateAuction;
using SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetAuctions;
using SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetByIDAuction;

namespace SourcingService.API.Controllers
{
    public class AuctionController : BaseController
    {
        private readonly IMediator _mediator;

        public AuctionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAuctions")]
        public async Task<IActionResult> GetAuctions()
        {
            GetAuctionsQueryResponse queryResponse = await _mediator.Send(new GetAuctionsQueryRequest());

            if (queryResponse.Response != null) return CreateActionResult(queryResponse.Response);

            return CreateActionResult(queryResponse.Auctions);
        }

        [HttpGet]
        [Route("getAuction/{id}")]
        public async Task<IActionResult> GetAuction(string id)
        {
            GetByIDAuctionQueryResponse queryResponse = await _mediator.Send(new GetByIDAuctionQueryRequest(id));

            if (queryResponse.Response != null) return CreateActionResult(queryResponse.Response);

            return CreateActionResult(queryResponse.Auction);
        }

        [HttpPost]
        [Route("createAuction")]
        public async Task<IActionResult> CreateAuction([FromBody] CreateAuctionCommandRequest request)
        {
            CreateAuctionCommandResponse commandResponse = await _mediator.Send(request);

            return CreateActionResult(commandResponse.Response);
        }

        [HttpPost]
        [Route("completeAuction/{id}")]
        public async Task<IActionResult> CompleteAuction(string id) 
        {
            CompleteAuctionCommandResponse commandResponse = await _mediator.Send(new CompleteAuctionCommandRequest(id));

            return CreateActionResult(commandResponse.Response);
        }

        [HttpPut]
        [Route("updateAuction")]
        public async Task<IActionResult> UpdateAuction([FromBody] UpdateAuctionCommandRequest request)
        {
            UpdateAuctionCommandResponse commandResponse = await _mediator.Send(request);

            return CreateActionResult(commandResponse.Response);
        }

        [HttpDelete]
        [Route("deleteAuction/{id}")]
        public async Task<IActionResult> DeleteAuction(string id)
        {
            DeleteAuctionCommandResponse commandResponse = await _mediator.Send(new DeleteAuctionCommandRequest(id));

            return CreateActionResult(commandResponse.Response);
        }
    }
}
