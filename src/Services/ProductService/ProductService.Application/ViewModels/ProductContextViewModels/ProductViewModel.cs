namespace ProductService.Application.ViewModels.ProductContextViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }

        public ProductViewModel(string id, DateTime createdDate, string name, string category, string summary, string description, string imageFile, decimal price) : base(id, createdDate)
        {
            Name = name;
            Category = category;
            Summary = summary;
            Description = description;
            ImageFile = imageFile;
            Price = price;
        }
    }
}
