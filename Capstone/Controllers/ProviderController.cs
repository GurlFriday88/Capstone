using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Data;
using Capstone.Models;
using Capstone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Controllers
{
    public class ProviderController : Controller
    {

        private CapstoneDBContext context;

        public ProviderController(CapstoneDBContext dbContext)
        {
            context = dbContext;
        }

        //Home for provider notes
        public IActionResult Index()
        {
            IList<Provider> Providers = context.Providers.ToList();

            return View(Providers);
        }

        //for detail view of note

        public IActionResult Detail(int id)
        {
            Provider providerToView = context.Providers.SingleOrDefault(p => p.ID == id);
            return View(providerToView);
        }

        //add for provider notes
        //get provider note
        public IActionResult Add()
        {
            AddProviderNoteViewModel addProviderViewModel = new AddProviderNoteViewModel(context.Providers.Include(p => p.Prefixes).Include(p => p.Patients).Include(p => p.Contact).ToList());
            return View(addProviderViewModel);

        }

        //post provider note
        public IActionResult Add(AddProviderNoteViewModel addProviderViewModel)
        {
            //grab the checkbox or select items from view model and find their matches in db
            IList<Prefix> selectedPrefixes =
                   context.Prefixes.Where(p => p.ID == addProviderViewModel.SelectedProvider).ToList();

            Contact contactItems = context.Contacts.FirstOrDefault(c => c.PhoneNumber == addProviderViewModel.PhoneNumber);

            IList<Patient> selectedPatients = context.Patients.Where(p => p.ID == addProviderViewModel.SelectedPatient).ToList();
            if (ModelState.IsValid)
            {
                // Add the new provider 
                Provider newProvider = new Provider
                {
                    Name = addProviderViewModel.Name,
                    SubscriberNumber = addProviderViewModel.SubscriberNumber,
                    PagesToSave = addProviderViewModel.PagesToSave,
                    SavedPagesDescription = addProviderViewModel.SavedPagesDescription,
                    PhoneNumber = contactItems.PhoneNumber,
                    Address = contactItems.Address,
                    BenefitRenewal = addProviderViewModel.BenefitRenewal,
                    AuthNote = addProviderViewModel.AuthNote,
                    MiscNotes = addProviderViewModel.MiscNotes,
                    Prefixes = selectedPrefixes,
                    Patients = selectedPatients


                };
                context.Providers.Add(newProvider);
                context.SaveChanges();
                return RedirectToAction("Detail");
            }
            return View("Add");


        }



        public IActionResult Edit()
        {
            ProviderNoteViewModel selectedNoteToUpdate = new ProviderNoteViewModel();

            return View(selectedNoteToUpdate);

        }







        //edit for provider notes

        public IActionResult Edit(ProviderNoteViewModel selectedNoteToUpdate)
        {
            Provider updateNote = context.Providers.FirstOrDefault(u => u.ID == selectedNoteToUpdate.ID);

            updateNote.Name = selectedNoteToUpdate.Name;
            updateNote.SubscriberNumber = selectedNoteToUpdate.SubscriberNumber;
            updateNote.PagesToSave = selectedNoteToUpdate.PagesToSave;
            updateNote.SavedPagesDescription = selectedNoteToUpdate.SavedPagesDescription;
            updateNote.Address = selectedNoteToUpdate.Address;
            updateNote.BenefitRenewal = selectedNoteToUpdate.BenefitRenewal;
            updateNote.AuthNote = selectedNoteToUpdate.AuthNote;
            updateNote.MiscNotes = selectedNoteToUpdate.MiscNotes;
            context.Providers.Update(updateNote);

            return RedirectToAction("Detail", updateNote.ID);
        }

        //delete for provider notes

        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Provider providerToDelete = context.Providers.SingleOrDefault(p => p.ID == id);
                context.Providers.Remove(providerToDelete); //query to delete the user selected provider  

                context.SaveChanges(); // commits changes to the db

                IList<Provider> remainingProviders = context.Providers.ToList();

                return View("ListProvider", remainingProviders);
            }


            return View("ListProvider");//send the user back to the list
        }

    }
}