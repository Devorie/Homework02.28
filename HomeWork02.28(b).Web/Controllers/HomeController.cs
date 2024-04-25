using HomeWork02._28_b_.Data.HomeWork_02._28.Data;
using HomeWork02._28_b_.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeWork02._28_b_.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;";

        public IActionResult Index()
        {
            PersonManager mgr = new(_connectionString);
            PersonViewModel vm = new();
            vm.Persons = mgr.GetPersons();
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<Person> persons)
        {
            PersonManager mgr = new(_connectionString);
            mgr.Add(persons);
            int count = 0;
            foreach(Person p in persons)
            {
                if (p.FirstName != null && p.LastName != null && p.BirthDay != null)
                {
                    count++;
                }
            }
            TempData["message"] = $"{count} added successfully!";
            return Redirect("/home/index");
        }
    }
}
