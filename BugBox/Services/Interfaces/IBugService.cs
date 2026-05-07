using BugBox.Models;

namespace BugBox.Services.Interfaces
{
    public interface IBugService
    {
        Task<List<Bug>> GetAllBugs();
        Task<Bug?> GetBugById(int id);
        Task<Bug> AddBug(Bug bug);
        Task<Bug?> EditBug(int id, Bug bug);
        Task<bool> DeleteBugById(int id);
    }
}
