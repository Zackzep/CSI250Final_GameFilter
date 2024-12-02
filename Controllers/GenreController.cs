using CSI250Final_GameFilter.Data;
using CSI250Final_GameFilter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CSI250Final_GameFilter.Controllers
{
    public class GenreController : Controller
    {
        ApplicationDbContext _context;

        public GenreController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Good
        public IActionResult Index(string sort)
        {

            IEnumerable<Genre> genres = _context.Genres;

            if (sort == "ascending")
            {
                genres = genres.OrderBy(x => x.Name);
            }
            else if (sort == "descending")
            {
                genres = genres.OrderByDescending(x => x.Name);
            }


            return View(genres);
        }

        //Good
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Genre genres = _context.Genres.SingleOrDefault(x => x.Id == id);

            if (genres is null)
            {
                return NotFound();
            }
            return View(genres);
        }

        //Good
        //[Authorize]
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid)
            {

                

                return View(genre);
            }

            _context.Genres.Add(genre);

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
            Genre genre = _context.Genres.SingleOrDefault(x => x.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                
                return View(genre);
            }


            _context.Genres.Update(genre);
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

            Genre genre = _context.Genres.SingleOrDefault(x => x.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        //Good
        [HttpPost]
        public IActionResult Delete(Genre genre)
        {
            if (genre.Id == 0)
            {
                return NotFound();
            }

            Genre g = _context.Genres.SingleOrDefault(x => x.Id == genre.Id);

            if (g == null)
            {
                return NotFound();
            }



            _context.Genres.Update(g);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
