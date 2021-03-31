using BowlingStuff.Models;
using BowlingStuff.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingStuff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context;

        public int itemsPerPage = 5;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext cxt)
        {
            _logger = logger;
            _context = cxt;
        }

        public IActionResult Index(long? teamid, string teamname, int pageNum)
        {
            if (teamname == null)
            {
                ViewData["teamname"] = "Home";
            }
            else
            {
                ViewData["teamname"] = teamname;
            }
            if (teamid == null)
            {
                ViewData["teamid"] = null;
            }
            else
            {
                ViewData["teamid"] = teamid;
            }

            return View(new IndexViewModel
            {
                Bowlers = (_context.Bowlers
            .Where(m => m.TeamId == teamid || teamid == null)
            .OrderBy(m => m.Team.TeamName)
            .Skip((pageNum - 1) * itemsPerPage)
             .Take(itemsPerPage)
            .ToList()),

                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = itemsPerPage,
                    CurrentPage = pageNum,
                    TotalNumItems = (teamid == null ? _context.Bowlers.Count() : _context.Bowlers.Where(x => x.TeamId == teamid).Count())
                }
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
