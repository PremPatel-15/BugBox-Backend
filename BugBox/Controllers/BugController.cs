using BugBox.DTOs.Bug;
using BugBox.Models;
using BugBox.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BugController : ControllerBase
    {
        private readonly IBugService bugService;

        public BugController(IBugService bugService)
        {
            this.bugService = bugService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBugs()
        {
            var records = await bugService.GetAllBugs();

            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIsBugs(int id)
        {
            var records = await bugService.GetBugById(id);

            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> PostAllBugs(CreateBugDto createBugDto)
        {
            try
            {
                await bugService.AddBug(createBugDto);

                return Ok(createBugDto);

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
                var record = await bugService.EditBug(id, bug);

                return Ok(record); 
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBugById(int id)
        {
            await bugService.DeleteBugById(id);

            return Ok(new { message = "Bug deleted successfully" });
        }
    }
}
