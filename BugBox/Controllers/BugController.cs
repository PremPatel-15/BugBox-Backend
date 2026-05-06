using BugBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BugController : ControllerBase
    {
        private readonly BugBoxContext context;

        public BugController(BugBoxContext context)
        {
            this.context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBugs()
        {
            var records = await context.Bugs.ToListAsync();

            if (records == null)
            {
                return NotFound("Data Not Found");
            }

            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIsBugs(int id)
        {
            var records = await context.Bugs.FindAsync(id);

            if (records == null)
            {
                return NotFound("Data Not Found");
            }

            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> PostAllBugs(Bug bug)
        {
            try
            {
                context.Bugs.Add(bug);
                await context.SaveChangesAsync();

                return Ok(bug);

            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutByIdBug(int id,Bug bug)
        {
            try
            {
                var record = await context.Bugs.FindAsync(id);

                if (record == null)
                {
                    return NotFound("Bug not found");
                }

                record.Title = bug.Title;
                record.Description = bug.Description;
                record.Priority = bug.Priority;
                record.Category = bug.Category;
                record.Rootcause = bug.Rootcause;
                record.Status = bug.Status;
                record.AssignedTo = bug.AssignedTo;

                await context.SaveChangesAsync();

                return Ok(record); 
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBugById(int id)
        {
            var bug = await context.Bugs.FindAsync(id);

            if (bug == null)
            {
                return NotFound(new { message = "Bug not found" });
            }

            context.Bugs.Remove(bug);
            await context.SaveChangesAsync();

            return Ok(new { message = "Bug deleted successfully" });
        }
    }
}
