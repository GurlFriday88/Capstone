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
    public class PrefixController : Controller
    {
        //access to database
        private CapstoneDBContext context;

        public PrefixController(CapstoneDBContext dbContext)
        {
            context = dbContext;
        }

        //home page for prefixes
        public IActionResult Index()
        {


            return View();
        }



        public IActionResult ListPrefixes()
        {
            IList<Prefix> allPrefixes = context.Prefixes.Include(b => b.Provider).ToList();

            return View(allPrefixes);
        }

        //routes to add prefix view

        public IActionResult Add()
        {
            AddPrefixViewModel addPrefixViewModel = new AddPrefixViewModel(context.Providers.ToList());
            return View(addPrefixViewModel);
        }

        //gets prefix form input and adds to db 

        [HttpPost]
        public IActionResult Add(AddPrefixViewModel addPrefixViewModel)
        {
            //variable to hold provider id user selected from dropdown in view 
            Provider selectedProvider =
                    context.Providers.SingleOrDefault(p => p.ProviderID == addPrefixViewModel.SelectedProvider);
            //checks to ensure form was filled 
            if (ModelState.IsValid)
            {
                // Add the new Prefix to my existing Prefixes
                Prefix newPrefix = new Prefix
                {
                    Name = addPrefixViewModel.Name,
                    ProviderID = selectedProvider.ProviderID
                };

                context.Prefixes.Add(newPrefix);
                context.SaveChanges();

                return Redirect("ListPrefixes");
            }

            return View(addPrefixViewModel); //if user input does not pass validation send user back to form
        }




        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                //variable stores the prefix found in the db  that matches the id of the prefix user selected for deletion 
                Prefix prefixToDelete = context.Prefixes.SingleOrDefault(p => p.PrefixID == id); 
                context.Prefixes.Remove(prefixToDelete); //query to delete the user selected prefix  

                context.SaveChanges(); // commits changes to the db

                IList<Prefix> remainingPrefixes = context.Prefixes.Include(b => b.Provider).ToList();

                return View("ListPrefixes", remainingPrefixes);
            }


            return View("ListPrefixes");//send the user back to the list
        }
    }






}