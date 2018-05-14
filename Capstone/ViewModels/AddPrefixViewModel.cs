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
        public int ProviderID { get; set; }

        //List of providers

        public IList<SelectListItem>Providers{ get; set; }

        //constructors 

        public AddPrefixViewModel()
        {

        }

        public AddPrefixViewModel(IEnumerable<Provider> providers)
        {
            Providers = new List<SelectListItem>();

            // <option value="0">Hard</option>

            foreach (Provider item in providers)
            {
                Providers.Add(new SelectListItem
                {
                    Value = ((int)item.ID).ToString(),
                    Text = item.Name.ToString()


                });

            }
        }
        
    }
}
