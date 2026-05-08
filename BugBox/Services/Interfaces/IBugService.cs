using BugBox.DTOs.Bug;
using BugBox.Models;

namespace BugBox.Services.Interfaces
{
    public interface IBugService
    {
        Task<List<BugResponseDto>> GetAllBugs();
        Task<BugResponseDto?> GetBugById(int id);
        Task<BugResponseDto> AddBug(CreateBugDto dto);
        Task<BugResponseDto> EditBug(int id, UpdateBugDto dto);
        Task<bool> DeleteBugById(int id);
    }
}
