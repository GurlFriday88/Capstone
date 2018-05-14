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
            IList<BcbsPrefix> bcbsPrefixes = context.BcbsPrefixes.Include(b => b.Provider).ToList();

            return View(bcbsPrefixes);
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
            Provider newProvider =
                    context.Providers.Single(p => p.ID == addPrefixViewModel.PrefixID);
            if (ModelState.IsValid)
            {
                // Add the new Prefix to my existing Prefixes
                BcbsPrefix newPrefix = new BcbsPrefix
                {
                    Prefix = addPrefixViewModel.Prefix,
                    ProviderID = newProvider.ID
                };

                context.BcbsPrefixes.Add(newPrefix); 
                context.SaveChanges(); 

                return Redirect("/Prefix"); //sends user back to the home page
            }

            return View(addPrefixViewModel); //if user inout does not pass validation send user back to the homepage with the form
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Prefixes";
            ViewBag.BcbsPrefixes = context.BcbsPrefixes.ToList(); //sends the user to the remove page showing all the prefises currently in db as option for deletion
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] prefixIds)
        {
            foreach (int prefixId in prefixIds)
            {
                BcbsPrefix thePrefix = context.BcbsPrefixes.Single(c => c.ID == prefixId); //thePrefix stores the prefix found in the db  that matches the id of the prefix user selected for deletion 
                context.BcbsPrefixes.Remove(thePrefix); //query to delete the user selected prefix  
            }

            context.SaveChanges(); // commits changes to the db

            return Redirect("/Prefix");//sends the user back to the homepage
        }
    }


      


    
}