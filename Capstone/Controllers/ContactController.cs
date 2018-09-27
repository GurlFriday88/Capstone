using System.Linq;
using Capstone.Data;
using Capstone.Models;
using Capstone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Capstone.Controllers
{
    public class ContactController : Controller
    {
        private CapstoneDBContext context;

        public ContactController(CapstoneDBContext dbContext)
        {
            context = dbContext;
        }
        

        public IActionResult Index( string searchString, string currentFilter, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            ContactViewModel allContacts = new ContactViewModel();
            allContacts.Providers = context.Providers.ToPagedList(pageNumber, pageSize);
            allContacts.Stores = context.Stores.ToPagedList(pageNumber, pageSize);




            return View (allContacts);
        }


       

    

        // GET: Contact/Create
       
        public IActionResult Add()
        {
            ContactViewModel addContactViewModel = new ContactViewModel();
            return View(addContactViewModel);

        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add( ContactViewModel contactViewModel)
        {
            
            if (ModelState.IsValid)
            {
                // Add the new store contact 
                Store newStore = new Store
                {
                    Name = contactViewModel.StoreModel.Name,
                    Address = contactViewModel.StoreModel.Address,
                    PhoneNumber = contactViewModel.StoreModel.PhoneNumber,
                    
    
                };
                context.Stores.Add(newStore);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();


        }

        // GET: Contact/Edit/5
        public IActionResult Edit(int id)
        {


            Store matchingStore= context.Stores.SingleOrDefault(m => m.StoreID == id);
            ContactViewModel storeToEdit = new ContactViewModel();

            storeToEdit.StoreModel.StoreID = matchingStore.StoreID;
            storeToEdit.StoreModel.Name = matchingStore.Name;
            storeToEdit.StoreModel.PhoneNumber = matchingStore.PhoneNumber;
            storeToEdit.StoreModel.Address = matchingStore.Address;


            return View(storeToEdit);

        }







        // POST: contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactViewModel contactToUpdate)
        {


            Store updateStore = context.Stores.SingleOrDefault(u => u.StoreID == contactToUpdate.StoreModel.StoreID);

            updateStore.Name = contactToUpdate.StoreModel.Name;
            updateStore.PhoneNumber = contactToUpdate.StoreModel.PhoneNumber;
            updateStore.Address = contactToUpdate.StoreModel.Address;
           
            context.Stores.Update(updateStore);
            context.SaveChanges();

            return RedirectToAction("index");
        }




        // POST: Provider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Store storeToDelete = context.Stores.SingleOrDefault(s => s.StoreID == id);
                context.Stores.Remove(storeToDelete); //query to delete the user selected provider  

                context.SaveChanges(); // commits changes to the db

               

                return View("Index");
            }


            return View("Index");//send the user back to the list
        }

    }
}


