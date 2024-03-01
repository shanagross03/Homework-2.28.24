using Homework_2._28._24.data;
using Homework_2._28._24.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework_2._28._24.Web.Controllers
{
    public class HomeController : Controller
    {
        private PersonManager mgr = new();

        public IActionResult Index()
        {
            return View(new PersonViewModel()
            {
                People = mgr.GetPeople(),
                PeopleAddedMessage = TempData["message"] != null ? (string[])TempData["message"] : null
            });
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            people = people.Where(p => p.FirstName != null && p.LastName != null && p.Age != 0).ToList();
            mgr.AddManyPeople(people);

            TempData["message"] = people.Select(p => $"{p.FirstName} {p.LastName} - {p.Age} added succesfully!").ToArray();
            return Redirect("/");
        }
    }
}