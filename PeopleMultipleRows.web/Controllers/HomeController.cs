using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleMultipleRows.web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PeopleMultipleRows.data;

namespace PeopleMultipleRows.web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress; Initial Catalog=People;Integrated Security=true;";
        public IActionResult Index()
        {
            PeopleDbManager db = new PeopleDbManager(_connectionString);
            DisplayPeopleViewModel vm = new DisplayPeopleViewModel();
            vm.PeopleList = db.GetAllPeople();
            return View(vm);
        }
        
        public IActionResult AddPerson()
        {
            return View();
        }
      
        [HttpPost]
        public IActionResult SubmitAddPerson(List<Person> people)
        {
            PeopleDbManager db = new PeopleDbManager(_connectionString);
            db.AddPerson(people);
            return Redirect("/");
        }
    }
}
