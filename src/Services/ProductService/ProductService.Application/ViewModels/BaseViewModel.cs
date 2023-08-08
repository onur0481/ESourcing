namespace ProductService.Application.ViewModels
{
    public class BaseViewModel
    {
        public string ID { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public BaseViewModel(string id, DateTime createdDate)
        {
            ID = id;
            CreatedDate = createdDate;
        }
    }
}
