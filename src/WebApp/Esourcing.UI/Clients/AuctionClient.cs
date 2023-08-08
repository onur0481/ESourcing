using Esourcing.UI.ViewModel;
using ESourcing.Core.Common;
using ESourcing.Core.ResultModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Esourcing.UI.Clients
{
    public class AuctionClient
    {
        public HttpClient _httpClient { get; }

        public AuctionClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(CommonInfo.LocalSourcingBaseAddress);
        }

        public async Task<Result<AuctionViewModel>> CreateAuction(AuctionViewModel viewModel)
        {
            var dataAsString = JsonConvert.SerializeObject(viewModel);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("/api/Auction/createAuction", content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AuctionViewModel>(responseData);

                if(result == null) return new Result<AuctionViewModel>(true, ResultConstant.RecordCreateNotSuccessfully);

                return new Result<AuctionViewModel>(true, ResultConstant.RecordCreateSuccessfully, result);
            }
            return new Result<AuctionViewModel>(true, ResultConstant.RecordCreateNotSuccessfully);
        }

        public async Task<Result<List<AuctionViewModel>>> GetAuctions()
        {
            var response = await _httpClient.GetAsync("/api/Auction/getAuctions");

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                APIResponseDTO<List<AuctionViewModel>>? result = JsonConvert.DeserializeObject<APIResponseDTO<List<AuctionViewModel>>>(responseData);

                if (result.Data != null)
                {
                    return new Result<List<AuctionViewModel>>(true, ResultConstant.RecordFound, result.Data);
                }

                return new Result<List<AuctionViewModel>>(false, ResultConstant.RecordNotFound);
            }

            return new Result<List<AuctionViewModel>>(false, ResultConstant.RecordNotFound);
        
        }

        public async Task<Result<AuctionViewModel>> GetAuctionById(string id)
        {
            var response = await _httpClient.GetAsync("/api/Auction/getAuction/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<APIResponseDTO<AuctionViewModel>>(responseData);

                if (result.Data != null)
                {
                    return new Result<AuctionViewModel>(true, ResultConstant.RecordFound, result.Data);
                }
                return new Result<AuctionViewModel>(false, ResultConstant.RecordNotFound);
            }
            return new Result<AuctionViewModel>(false, ResultConstant.RecordNotFound);
        }

        public async Task<Result<string>> CompleteBid(string id)
        {
            var dataAsString = JsonConvert.SerializeObject(id);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var url = $"/api/Auction/completeAuction/{id}";
            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync(); 
                return new Result<string>(true,ResultConstant.RecordCreateSuccessfully,responseData);
            }
            return new Result<string>(false, ResultConstant.RecordCreateNotSuccessfully);
        }
    }
}
