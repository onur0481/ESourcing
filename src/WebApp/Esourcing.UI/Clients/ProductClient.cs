using Esourcing.UI.ViewModel;
using ESourcing.Core.Common;
using ESourcing.Core.ResultModels;
using Newtonsoft.Json;

namespace Esourcing.UI.Clients
{
    public class ProductClient
    {
        public HttpClient _client { get; }

        public ProductClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(CommonInfo.LocalProductBaseAddress);
        }

        public async Task<Result<List<ProductViewModel>>> GetProducts()
        {
            var response = await _client.GetAsync("/api/Product/getProducts");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                APIResponseDTO<List<ProductViewModel>>? result = JsonConvert.DeserializeObject<APIResponseDTO<List<ProductViewModel>>>(responseData);

                if (result.Data != null)
                {
                    return new Result<List<ProductViewModel>>(true, ResultConstant.RecordFound, result.Data); // Burada result.Data'ya dikkat edin.
                }

                return new Result<List<ProductViewModel>>(false, ResultConstant.RecordNotFound);
            }

            return new Result<List<ProductViewModel>>(false, ResultConstant.RecordNotFound); // HTTP 200 (Success) olmadığında bile bir sonuç döndürülmeli.
        }
    }
}
