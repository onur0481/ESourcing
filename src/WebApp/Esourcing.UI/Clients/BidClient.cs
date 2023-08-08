using Esourcing.UI.ViewModel;
using ESourcing.Core.Common;
using ESourcing.Core.ResultModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Esourcing.UI.Clients
{
    public class BidClient
    {
        public HttpClient _bidClient { get;}

        public BidClient(HttpClient bidClient)
        {
            _bidClient = bidClient;
            _bidClient.BaseAddress = new Uri(CommonInfo.LocalSourcingBaseAddress);
        }

        public async Task<Result<List<BidViewModel>>> GetAllBidsByAuctionId(string id)
        {
            var response = await _bidClient.GetAsync("/api/Bid/getBidsAuctionID/" + id);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                APIResponseDTO<List<BidViewModel>>? result = JsonConvert.DeserializeObject<APIResponseDTO<List<BidViewModel>>>(responseData);

                if(result.Data != null)
                {
                    return new Result<List<BidViewModel>>(true, ResultConstant.RecordFound, result.Data);
                }
                return new Result<List<BidViewModel>>(false, ResultConstant.RecordNotFound);
            }
            return new Result<List<BidViewModel>>(false, ResultConstant.RecordNotFound);
        }

        public async Task<Result<string>> SendBind(BidViewModel model)
        {
            var dataAsString = JsonConvert.SerializeObject(model);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _bidClient.PostAsync("/api/Bid/createBid", content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<string>(true, ResultConstant.RecordCreateSuccessfully,responseData);
            }
            return new Result<string>(false, ResultConstant.RecordCreateNotSuccessfully);
        }
    }
}
