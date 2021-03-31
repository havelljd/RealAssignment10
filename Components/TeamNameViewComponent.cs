using BowlingStuff.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingStuff.Components
{
    public class TeamNameViewComponent : ViewComponent
    {
        private BowlingLeagueContext _context;
        public TeamNameViewComponent(BowlingLeagueContext txt)
        {
            _context = txt;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Teams.Distinct().OrderBy(x => x));
        }
    }
}
