using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingStuff.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowler> Bowlers { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
