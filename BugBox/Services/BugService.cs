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

        public async Task<List<Bug>> GetAllBugs()
        {
            return await context.Bugs.ToListAsync();
        }

        public async Task<Bug?> GetBugById(int id)
        {
            return await context.Bugs.FindAsync(id);
        }

        public async Task<Bug> AddBug(Bug bug)
        {
            await context.Bugs.AddAsync(bug);
            await context.SaveChangesAsync();

            return bug;
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
