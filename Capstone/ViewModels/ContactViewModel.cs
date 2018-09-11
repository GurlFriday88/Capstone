using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.ViewModels
{
    public class ContactViewModel
    {

        public Provider ProviderModel{get; set;}
        public Store StoreModel { get; set; }




        public IList<Provider> Providers { get; set; }

        public IList<Store> Stores { get; set; }

        public ContactViewModel()
        {

        }
    }


}
