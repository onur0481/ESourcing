namespace SourcingService.Application.ViewModels
{
    public class BaseViewModel
    {
        public string ID { get; private set; }

        public BaseViewModel(string id)
        {
            ID = id;
        }
    }
}
