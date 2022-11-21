using MallconomyCase.Models;

namespace MallconomyCase.IRepository
{
    public interface IUserPointRepository
    {
        void BulkSave(List<UserPoint> userPoints);
        Task<List<UserPoint>> GetAsync();
        Task<UserPoint?> GetAsync(string id);
        Task<List<UserPoint>> GetAsync(bool approved);
        Task<List<UserPoint>> GetByUserIdAsync(string userId);
        Task CreateAsync(UserPoint newUserPoint);
        Task UpdateAsync(UserPoint updatedUserPoint);
    }
}
