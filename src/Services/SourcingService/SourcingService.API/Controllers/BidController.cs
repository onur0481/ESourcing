using MediatR;
using Microsoft.AspNetCore.Mvc;
using SourcingService.Application.CQRS.BidContextCQRSs.CommandCreateBid;
using SourcingService.Application.CQRS.BidContextCQRSs.QueryGetBidAuctionID;
using SourcingService.Application.CQRS.BidContextCQRSs.QueryGetWinnerBid;

namespace SourcingService.API.Controllers
{
    public class BidController : BaseController
    {
        private readonly IMediator _mediator;

        public BidController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getBidsAuctionID/{id}")]
        public async Task<IActionResult> GetBidAuctionID(string id)
        {
            GetBidAuctionIDQueryResponse queryResponse = await _mediator.Send(new GetBidAuctionIDQueryRequest(id));

            if (queryResponse.Response != null) return CreateActionResult(queryResponse.Response);

            return CreateActionResult(queryResponse.Bids);
        }

        [HttpGet]
        [Route("getWinnerBid/{id}")]
        public async Task<IActionResult> GetWinnerBid(string id)
        {
            GetWinnerBidQueryResponse queryResponse = await _mediator.Send(new GetWinnerBidQueryRequest(id));

            if (queryResponse.Response != null) return CreateActionResult(queryResponse.Response);

            return CreateActionResult(queryResponse.Bids);
        }

        [HttpPost]
        [Route("createBid")]
        public async Task<IActionResult> CreateBid([FromBody] CreateBidCommandRequest request)
        {
            CreateBidCommandResponse commandResponse = await _mediator.Send(request);

            return CreateActionResult(commandResponse.Response);
        }
    }
}
