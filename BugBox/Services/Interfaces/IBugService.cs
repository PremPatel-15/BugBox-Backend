using BugBox.DTOs.Bug;
using BugBox.Models;

namespace BugBox.Services.Interfaces
{
    public interface IBugService
    {
        Task<List<BugResponseDto>> GetAllBugs();
        Task<BugResponseDto?> GetBugById(int id);
        Task<BugResponseDto> AddBug(CreateBugDto dto);
        Task<Bug?> EditBug(int id, Bug bug);
        Task<bool> DeleteBugById(int id);
    }
}
