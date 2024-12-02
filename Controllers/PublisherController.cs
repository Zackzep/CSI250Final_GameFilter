using CSI250Final_GameFilter.Data;
using CSI250Final_GameFilter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CSI250Final_GameFilter.Controllers
{
    public class PublisherController : Controller
    {
        ApplicationDbContext _context;

        public PublisherController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Good
        public IActionResult Index(string sortName, string sortCity, string country)
        {

            IEnumerable<Publisher> publishers = _context.Publishers;

            if (sortName == "ascendingName")
            {
                publishers = publishers.OrderBy(x => x.Name);
            }
            else if (sortName == "descendingName")
            {
                publishers = publishers.OrderByDescending(x => x.Name);
            }
            if (sortCity == "ascendingCity")
            {
                publishers = publishers.OrderBy(x => x.City);
            }
            else if (sortCity == "descendingCity")
            {
                publishers = publishers.OrderByDescending(x => x.City);
            }
            if (!String.IsNullOrEmpty(country))
            {

                IEnumerable<Publisher> filteredPublishersName = publishers.Where(x => x.Country.ToLower().Contains(country.ToLower()));
                return View(filteredPublishersName);
            }

            return View(publishers);
        }

        //Good
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Publisher publishers = _context.Publishers.SingleOrDefault(x => x.Id == id);

            if (publishers is null)
            {
                return NotFound();
            }
            return View(publishers);
        }

        //Good
        //[Authorize]
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {



                return View(publisher);
            }

            _context.Publishers.Add(publisher);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Good
        //[Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {


            if (id == 0)
            {
                return NotFound();
            }
            Publisher publisher = _context.Publishers.SingleOrDefault(x => x.Id == id);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }
        [HttpPost]
        public IActionResult Edit(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {

                return View(publisher);
            }


            _context.Publishers.Update(publisher);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        //Good
        //[Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Publisher publisher = _context.Publishers.SingleOrDefault(x => x.Id == id);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }
        //Good
        [HttpPost]
        public IActionResult Delete(Publisher publisher)
        {
            if (publisher.Id == 0)
            {
                return NotFound();
            }

            Publisher p = _context.Publishers.SingleOrDefault(x => x.Id == publisher.Id);

            if (p == null)
            {
                return NotFound();
            }



            _context.Publishers.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
