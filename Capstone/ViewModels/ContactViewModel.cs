using Capstone.Models;
using X.PagedList;

namespace Capstone.ViewModels
{
    public class ContactViewModel
    {

        public Store StoreModel { get; set; }
        public Provider ProviderModel { get; set; }

        public IPagedList<Provider> Providers { get; set; }
        public IPagedList<Store> Stores { get; set; }

        public ContactViewModel()
        {
        }
    }


}
