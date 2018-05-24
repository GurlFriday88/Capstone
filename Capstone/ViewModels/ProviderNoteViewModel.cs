using Capstone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Capstone.ViewModels
{
    public class ProviderNoteViewModel
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string SubscriberNumber { get; set; }


        public int PagesToSave { get; set; }

        public string SavedPagesDescription { get; set; }

        public string BenefitRenewal { get; set; }

        public string AuthNote { get; set; }

        public string MiscNotes { get; set; }


        public string Address { get; set; }


        public string PhoneNumber { get; set; }




        public Prefix Prefix { get; set; }
        public Patient Patient { get; set; }

        //Set up for drop down lists 

        public int SelectedProvider { get; set; }

        public int SelectedPatient { get; set; }

        //List of providers

        public IList<SelectListItem> Prefixes { get; set; }

        public IList<SelectListItem> Patients { get; set; }

        //constructors 

        public ProviderNoteViewModel()
        {

        }

        public ProviderNoteViewModel(IEnumerable<Prefix> prefix)
        {
            Prefixes = new List<SelectListItem>();

            // <option value="0">Hard</option>

            foreach (Prefix item in prefix)
            {
                Prefixes.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name.ToString()


                });

            }
        }

        public ProviderNoteViewModel(IEnumerable<Patient> patients)
        {
            Patients = new List<SelectListItem>();

            // <option value="0">Hard</option>

            foreach (Patient item in patients)
            {
                Patients.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Type.ToString()


                });

            }
        }
    }
}

