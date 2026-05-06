using BugBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugBox.Controllers
{
    [ApiController]
    [Route("dashboard")]
    public class DashboardController : Controller
    {
        private readonly BugBoxContext context;

        public DashboardController(BugBoxContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("bugcount")]
        public IActionResult SumOfTotalBugs()
        {
            var record = context.Bugs.Count();
            return Ok(record);
        }

        [HttpGet("priority")]
        public IActionResult Priority()
        {
            var high = (from b in context.Bugs
                        where b.Priority == "High"
                        select b.Id).ToList().Count();

            var medium = (from b in context.Bugs
                          where b.Priority == "Medium"
                          select b.Id).ToList().Count();

            var low = (from b in context.Bugs
                       where b.Priority == "Low"
                       select b.Id).ToList().Count();

            return Ok(new { HighCount = high, MediumCount = medium, LowCount = low });
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            var open = (from b in context.Bugs
                        where b.Status == "Open"
                        select b.Id).ToList().Count();

            var inProgress = (from b in context.Bugs
                              where b.Status == "In Progress"
                              select b.Id).ToList().Count();

            var resolved = (from b in context.Bugs
                            where b.Status == "Resolved"
                            select b.Id).ToList().Count();

            return Ok(new { OpenCount = open, InProgressCount = inProgress, ResolvedCount = resolved });
        }

        [HttpGet("developer")]
        public IActionResult BugsPerDeveloper()
        {
            var result = from b in context.Bugs
                         group b by b.AssignedTo into g
                         select new
                         {
                             Developer = g.Key,
                             BugCount = g.Count()
                         };

            return Ok(result);
        }

    }
}
