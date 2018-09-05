using System.Collections.Generic;
using System.Linq;
using Capstone.Data;
using Capstone.Models;
using Capstone.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class ProviderController : Controller
    {
        private CapstoneDBContext context;

        public ProviderController(CapstoneDBContext dbContext)
        {
            context = dbContext;
        }
        // GET: Provider
        public IActionResult Index()
        {
            IList<Provider> Providers = context.Providers.ToList();

            return View(Providers);
        }

        // GET: Provider/Details/5
        public IActionResult Detail(int id)
        {
            Provider providerToView = context.Providers.SingleOrDefault(p => p.ProviderID == id);

            return View(providerToView);
        }

        // GET: Provider/Create
        public IActionResult Add()
        {
            AddProviderNoteViewModel addProviderViewModel = new AddProviderNoteViewModel();
            return View(addProviderViewModel);

        }

        // POST: Provider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddProviderNoteViewModel addProviderViewModel)
        {
            //grab the checkbox or select items from view model and find their matches in db
            IList<Prefix> selectedPrefixes =
                   context.Prefixes.Where(p => p.PrefixID == addProviderViewModel.SelectedProvider).ToList();  //change ling query to any 



            IList<Patient> selectedPatients = context.Patients.Where(p => p.PatientID == addProviderViewModel.SelectedPatient).ToList();
            if (ModelState.IsValid)
            {
                // Add the new provider 
                Provider newProvider = new Provider
                {
                    Name = addProviderViewModel.Name,
                    PhoneNumber= addProviderViewModel.PhoneNumber,
                    SubscriberNumber = addProviderViewModel.SubscriberNumber,
                    PagesToSave = addProviderViewModel.PagesToSave,
                    SavedPagesDescription = addProviderViewModel.SavedPagesDescription,
                    BenefitRenewal = addProviderViewModel.BenefitRenewal,
                    AuthNote = addProviderViewModel.AuthNote,
                    MiscNotes = addProviderViewModel.MiscNotes,



                };
                context.Providers.Add(newProvider);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();


        }


        // GET: Provider/Edit/5
        public IActionResult Edit(int id)
        {

            
            Provider matchingProvider = context.Providers.SingleOrDefault(p => p.ProviderID == id);
            ProviderViewModel providerToEdit = new ProviderViewModel();

            providerToEdit.ProviderID = matchingProvider.ProviderID;
            providerToEdit.Name = matchingProvider.Name;
            providerToEdit.PhoneNumber = matchingProvider.PhoneNumber;
            providerToEdit.PagesToSave = matchingProvider.PagesToSave;
            providerToEdit.SubscriberNumber = matchingProvider.SubscriberNumber;
            providerToEdit.SavedPagesDescription = matchingProvider.SavedPagesDescription;
            providerToEdit.BenefitRenewal = matchingProvider.BenefitRenewal;
            providerToEdit.AuthNote = matchingProvider.AuthNote;
            providerToEdit.MiscNotes = matchingProvider.MiscNotes;

            return View(providerToEdit);
        }

        // POST: Provider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProviderViewModel selectedNoteToUpdate)
        {
           

            Provider updateNote = context.Providers.SingleOrDefault(u => u.ProviderID == selectedNoteToUpdate.ProviderID);

            updateNote.Name = selectedNoteToUpdate.Name;
            updateNote.SubscriberNumber = selectedNoteToUpdate.SubscriberNumber;
            updateNote.PagesToSave = selectedNoteToUpdate.PagesToSave;
            updateNote.SavedPagesDescription = selectedNoteToUpdate.SavedPagesDescription;
            updateNote.BenefitRenewal = selectedNoteToUpdate.BenefitRenewal;
            updateNote.AuthNote = selectedNoteToUpdate.AuthNote;
            updateNote.MiscNotes = selectedNoteToUpdate.MiscNotes;
            context.Providers.Update(updateNote);
            context.SaveChanges();

            return RedirectToAction("Detail", new { id = selectedNoteToUpdate.ProviderID});
        }


        

        // POST: Provider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Provider providerToDelete = context.Providers.SingleOrDefault(p => p.ProviderID == id);
                context.Providers.Remove(providerToDelete); //query to delete the user selected provider  

                context.SaveChanges(); // commits changes to the db

                IList<Provider> remainingProviders = context.Providers.ToList();

                return View("Index", remainingProviders);
            }


            return View("Index");//send the user back to the list
        }

    }
}
