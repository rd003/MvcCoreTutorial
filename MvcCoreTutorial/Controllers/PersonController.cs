using Microsoft.AspNetCore.Mvc;
using MvcCoreTutorial.Models.Domain;

namespace MvcCoreTutorial.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx) {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.greeting = "Hello world";
            ViewData["greeting2"] = "I am using ViewData";
            //ViewBag and ViewData can send data only from ControllerToView

            //Tempdata can send data from one controller method to another controller method
            TempData["greeting3"] = "Its TempData msg";
            return View();
        }

        //it is get method
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Added successfully";
                return RedirectToAction("AddPerson");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added!!!";
                return View();
            }

        }

        public IActionResult DisplayPersons()
        {
            var persons = _ctx.Person.ToList();
            return View(persons);
        }

        public IActionResult EditPerson(int id)
        {
            var person = _ctx.Person.Find(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Person.Update(person);
                _ctx.SaveChanges();
                return RedirectToAction("DisplayPersons");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not update!!!";
                return View();
            }

        }

        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = _ctx.Person.Find(id);
                if (person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                
            }
            return RedirectToAction("DisplayPersons");
            
        }
    }
}
