using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Data;
using Capstone.Models;
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

        //public IActionResult Add()
        //{
        //    AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());
        //    return View(addCheeseViewModel);
        //}

        //[HttpPost]
        //public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        //{
        //    CheeseCategory newCheeseCategory =
        //            context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);
        //    if (ModelState.IsValid)
        //    {
        //        // Add the new cheese to my existing cheeses
        //        Cheese newCheese = new Cheese
        //        {
        //            Name = addCheeseViewModel.Name,
        //            Description = addCheeseViewModel.Description,
        //            CategoryID = newCheeseCategory.ID
        //        };

        //        context.Cheeses.Add(newCheese); //adds the newly made cheese object to the db 
        //        context.SaveChanges(); //commits the new cheese to the db (saves it)

        //        return Redirect("/Cheese"); //sends user back to the home page
        //    }

        //    return View(addCheeseViewModel); //if user inout does not pass validation send user back to the homepage with the form to add cheese along with any error messages
        //}

        //public IActionResult Remove()
        //{
        //    ViewBag.title = "Remove Cheeses";
        //    ViewBag.cheeses = context.Cheeses.ToList(); //sends the user to the remove page showing all the cheeses currently in db as  option for deletion
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Remove(int[] cheeseIds)
        //{
        //    foreach (int cheeseId in cheeseIds)
        //    {
        //        Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId); //theCheese stores the cheese found in the db  that matches the id of the cheese user selected for deletion 
        //        context.Cheeses.Remove(theCheese); //query to delete the user selected cheese from the db 
        //    }

        //    context.SaveChanges(); // commits changes to the db

        //    return Redirect("/");//sends the user back to the homepage
        //}
    }


      


    
}