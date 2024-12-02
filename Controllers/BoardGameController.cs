using System.Security.Principal;
using CSI250Final_GameFilter.Data;
using CSI250Final_GameFilter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CSI250Final_GameFilter.Controllers
{
    public class BoardGameController : Controller
    {
        ApplicationDbContext _context;

        public BoardGameController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Good
        public IActionResult Index(decimal price, string gameName, string genre, string publisher, int difficulty,
            string diffFilterType, int playerCount, int year, string yearFilterType)
        {
            IEnumerable<BoardGame> boardGames = _context.BoardGames.Include(x => x.Genre).Include(x => x.Publisher);
            IEnumerable<decimal> prices = _context.BoardGames.Select(x => x.Cost).Distinct();
            IEnumerable<string> genres = _context.BoardGames.Select(x => x.Genre.Name).Distinct();
            IEnumerable<string> publishers = _context.BoardGames.Select(x => x.Publisher.Name).Distinct();
            IEnumerable<int> difficulties = _context.BoardGames.Select(x => x.Complexity).Distinct();
            IEnumerable<int> playerCounts = _context.BoardGames.Select(x => x.PlayerCount).Distinct();
            IEnumerable<int> years = _context.BoardGames.Select(x => x.ReleaseYear).Distinct();

            IEnumerable<SelectListItem> selectListPrice = prices.Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString(),
                Selected = x == price
            });
            IEnumerable<SelectListItem> selectListDiff = difficulties.Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString(),
                Selected = x == difficulty
            });
            IEnumerable<SelectListItem> selectListYear = years.Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString(),
                Selected = x == year
            });
            IEnumerable<SelectListItem> selectListPlayerCount = playerCounts.Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString(),
                Selected = x == playerCount
            });
            IEnumerable<SelectListItem> selectListGenre = genres.Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString(),
                Selected = x == genre
            });
            IEnumerable<SelectListItem> selectListPublisher = publishers.Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString(),
                Selected = x == publisher
            });
            ViewBag.playerCountFilter = selectListPlayerCount;
            ViewBag.difficultyFilter = selectListDiff;
            ViewBag.genreFilter = selectListGenre;
            ViewBag.priceFilter = selectListPrice;
            ViewBag.publisherFilter = selectListPublisher;
            ViewBag.yearFilter = selectListYear;


            if (!String.IsNullOrEmpty(yearFilterType))
            {
                if (year != 0)
                {
                    if (yearFilterType == "after")
                    {
                        boardGames = boardGames.Where(x => x.ReleaseYear > year);
                        
                    }
                    else if (yearFilterType == "before")
                    {
                        boardGames = boardGames.Where(x => x.ReleaseYear < year);
                    }
                }
            }
            if (!String.IsNullOrEmpty(diffFilterType))
            {
                if (difficulty != 0)
                {
                    if (diffFilterType == "above")
                    {
                        boardGames = boardGames.Where(x => x.Complexity > difficulty);

                    }
                    else if (diffFilterType == "below")
                    {
                        boardGames = boardGames.Where(x => x.Complexity < difficulty);
                    }
                }
            }
            if (playerCount != 0)
            {
                boardGames = boardGames.Where(x => x.PlayerCount == playerCount);
            }
            if (price != 0)
            {
                boardGames = boardGames.Where(x => x.Cost == price);
            }
            
            if (!String.IsNullOrEmpty(genre))
            {
                boardGames = boardGames.Where(x => x.Genre.Name == genre);
                return View(boardGames);
            }

            if (!String.IsNullOrEmpty(publisher))
            {
                boardGames = boardGames.Where(x => x.Publisher.Name == publisher);
                return View(boardGames);
            }

            if (!String.IsNullOrEmpty(gameName))
            {

                IEnumerable<BoardGame> filteredBoardGames = _context.BoardGames.Include(x => x.Genre).Include(x => x.Publisher).Where(x => x.Title.ToLower().Contains(gameName.ToLower()));
                return View(filteredBoardGames);
            }

            // Check if the filtered board games collection is empty so games display on load
            if (!boardGames.Any()) 
            {
                boardGames = _context.BoardGames.Include(x => x.Genre).Include(x => x.Publisher);
            }


            return View(boardGames);
        }

        //Good
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            BoardGame boardGame = _context.BoardGames.Include(_x => _x.Genre).Include(_x => _x.Publisher).SingleOrDefault(x => x.Id == id);

            if (boardGame is null)
            {
                return NotFound();
            }
            return View(boardGame);
        }

        //Good
        //[Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            
            IEnumerable<SelectListItem> selectListGenre = _context.Genres.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name

            });
            IEnumerable<SelectListItem> selectListPublisher = _context.Publishers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name

            });
            ViewBag.GenreList = selectListGenre;
            ViewBag.PublisherList = selectListPublisher;

            return View();
        }
        [HttpPost]
        public IActionResult Create(BoardGame boardGame)
        {
            if (!ModelState.IsValid)
            {
                
                IEnumerable<SelectListItem> selectListGenre = _context.Genres.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name

                });
                IEnumerable<SelectListItem> selectListPublisher = _context.Publishers.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name

                });
                ViewBag.GenreList = selectListGenre;
                ViewBag.PublisherList = selectListPublisher;

                return View(boardGame);
            }
            
            _context.BoardGames.Add(boardGame);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Good
        //[Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            IEnumerable<SelectListItem> selectListGenre = _context.Genres.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name

            });
            IEnumerable<SelectListItem> selectListPublisher = _context.Publishers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name

            });
            ViewBag.GenreList = selectListGenre;
            ViewBag.PublisherList = selectListPublisher;

            if (id == 0)
            {
                return NotFound();
            }
            BoardGame boardGame = _context.BoardGames.SingleOrDefault(x => x.Id == id);

            if (boardGame == null)
            {
                return NotFound();
            }

            return View(boardGame);
        }
        [HttpPost]
        public IActionResult Edit(BoardGame boardGame)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<SelectListItem> selectListGenre = _context.Genres.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name

                });
                IEnumerable<SelectListItem> selectListPublisher = _context.Publishers.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name

                });
                ViewBag.GenreList = selectListGenre;
                ViewBag.PublisherList = selectListPublisher;
                return View(boardGame);
            }


            _context.BoardGames.Update(boardGame);
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

            BoardGame boardGame = _context.BoardGames.Include(_x => _x.Genre).Include(_x => _x.Publisher).SingleOrDefault(x => x.Id == id);

            if (boardGame == null)
            {
                return NotFound();
            }

            return View(boardGame);
        }
        [HttpPost]
        public IActionResult Delete(BoardGame boardGame)
        {
            if (boardGame.Id == 0)
            {
                return NotFound();
            }

            BoardGame b = _context.BoardGames.SingleOrDefault(x => x.Id == boardGame.Id);

            if (b == null)
            {
                return NotFound();
            }



            _context.BoardGames.Update(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
