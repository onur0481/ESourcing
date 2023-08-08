using MediatR;

namespace ProductService.Application.CQRS.ProductContextCQRSs.CommandUpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }

        public UpdateProductCommandRequest(string id, string name, string category, string summary, string description, string imageFile, decimal price)
        {
            ID = id;
            Name = name;
            Category = category;
            Summary = summary;
            Description = description;
            ImageFile = imageFile;
            Price = price;
        }
    }
}
