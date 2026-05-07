using BugBox.DTOs.Bug;
using BugBox.Models;
using BugBox.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BugBox.Services
{
    public class BugService : IBugService
    {
        private readonly BugBoxContext context;
        public BugService(BugBoxContext context)
        {
            this.context = context;
        }

        public async Task<List<BugResponseDto>> GetAllBugs()
        {
            return await context.Bugs.Select(b => new BugResponseDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Priority = b.Priority,
                Category = b.Category,
                Rootcause = b.Rootcause,
                Status = b.Status,
                AssignedTo = b.AssignedTo,
                CreatedDate = b.CreatedDate
            }).ToListAsync();
        }

        public async Task<BugResponseDto?> GetBugById(int id)
        {
            return await context.Bugs
                .Where(b => b.Id == id)
                .Select(b => new BugResponseDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Priority = b.Priority,
                    Category = b.Category,
                    Rootcause = b.Rootcause,
                    Status = b.Status,
                    AssignedTo = b.AssignedTo,
                    CreatedDate = b.CreatedDate
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BugResponseDto> AddBug(CreateBugDto dto)
        {
            var bug = new Bug
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                Category = dto.Category,
                Rootcause = dto.Rootcause,
                Status = dto.Status,
                AssignedTo = dto.AssignedTo
            };

            await context.Bugs.AddAsync(bug);
            await context.SaveChangesAsync();

            var response = new BugResponseDto
            {
                Id = bug.Id,
                Title = bug.Title,
                Description = bug.Description,
                Priority = bug.Priority,
                Category = bug.Category,
                Rootcause = bug.Rootcause,
                Status = bug.Status,
                AssignedTo = bug.AssignedTo,
                CreatedDate = bug.CreatedDate
            };

            return response;
        }

        public async Task<Bug?> EditBug(int id, Bug bug)
        {
            var record = await context.Bugs.FindAsync(id);

            if (record == null)
            {
                return null;
            }

            record.Title = bug.Title;
            record.Description = bug.Description;
            record.Priority = bug.Priority;
            record.Category = bug.Category;
            record.Rootcause = bug.Rootcause;
            record.Status = bug.Status;
            record.AssignedTo = bug.AssignedTo;

            await context.SaveChangesAsync();

            return record;
        }

        public async Task<bool> DeleteBugById(int id)
        {
            var bug = await context.Bugs.FindAsync(id);

            if (bug == null)
            {
                return false;
            }

            context.Bugs.Remove(bug);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
