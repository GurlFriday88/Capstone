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
        //home
        private CapstoneDBContext context;

        public PrefixController(CapstoneDBContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {


            return View();
        }



        public IActionResult ListAllPrefixes()
        {
            IList<Prefix> Prefixes = context.Prefixes.Include(b => b.Provider).ToList();

            return View(Prefixes);
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
            Provider selectedProvider =
                    context.Providers.SingleOrDefault(p => p.ProviderID == addPrefixViewModel.SelectedProvider);
            if (ModelState.IsValid)
            {
                // Add the new Prefix to my existing Prefixes
                Prefix newPrefix = new Prefix
                {
                    Name = addPrefixViewModel.Prefix,
                    ProviderID = selectedProvider.ProviderID
                };

                context.Prefixes.Add(newPrefix);
                context.SaveChanges();

                return Redirect("ListAllPrefixes");
            }

            return View(addPrefixViewModel); //if user inout does not pass validation send user back to the homepage with the form
        }




        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Prefix prefixToDelete = context.Prefixes.SingleOrDefault(p => p.PrefixID == id); //thePrefix stores the prefix found in the db  that matches the id of the prefix user selected for deletion 
                context.Prefixes.Remove(prefixToDelete); //query to delete the user selected prefix  

                context.SaveChanges(); // commits changes to the db

                IList<Prefix> remainingPrefixes = context.Prefixes.Include(b => b.Provider).ToList();

                return View("ListAllPrefixes", remainingPrefixes);
            }


            return View("ListAllPrefixes");//send the user back to the list
        }
    }






}