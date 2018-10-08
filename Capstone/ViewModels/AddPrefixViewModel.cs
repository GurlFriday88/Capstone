using Capstone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Capstone.ViewModels
{
    public class AddPrefixViewModel
    {

        public int PrefixID { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage ="Select A Provider From List!")]
        public int SelectedProvider { get; set; }

        public IPagedList<Prefix> Prefixes { get; set; }

        //List of providers

        public IList<SelectListItem>Providers{ get; set; }

        //constructor

        public AddPrefixViewModel()
        {

        }


        //constructor for select list of providers 

        public AddPrefixViewModel(IEnumerable<Provider> providers)
        {
            Providers = new List<SelectListItem>();

            // <option value="0">Hard</option>

            foreach (Provider item in providers)
            {
                Providers.Add(new SelectListItem
                {
                    Value = item.ProviderID.ToString(),
                    Text = item.Name.ToString()


                });

            }
        }
        
    }
}
