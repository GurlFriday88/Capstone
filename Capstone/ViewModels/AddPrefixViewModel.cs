using Capstone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.ViewModels
{
    public class AddPrefixViewModel
    {

        public int PrefixID { get; set; }

        [Required]
        [Display(Name ="Alpha Prefix")]
        public string Prefix { get; set; }

        [Required]
        public int SelectedProvider { get; set; }

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
