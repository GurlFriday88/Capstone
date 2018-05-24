using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class ProviderController : Controller
    {

        //Home for provider notes
        public IActionResult Index()
        {
            return View();
        }

        //for detail view of note

        public IActionResult Detail()
        {
            return View();
        }

        //add for provider notes

        public IActionResult Add()
        {
            return View();
        }

        //edit for provider notes

        public IActionResult Edit()
        {
            return View();
        }

        //delete for provider notes

        public IActionResult Delete()
        {
            return View();
        }

    }
}