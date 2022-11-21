using MallconomyCase.IRepository;
using MallconomyCase.Models;
using MongoDB.Driver;
using System.Linq;

namespace MallconomyCase.Repository
{
    public class UserPointRepository : IUserPointRepository
    {

        private readonly IMongoCollection<UserPoint> _userPointCollection;

        public UserPointRepository(IUserPointDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userPointCollection = database.GetCollection<UserPoint>(settings.UserPointCollectionName);
        }

        public void BulkSave(List<UserPoint> userPoints)
        {
            _userPointCollection.InsertMany(userPoints);
        }

        public async Task CreateAsync(UserPoint newUserPoint)
        {
            await _userPointCollection.InsertOneAsync(newUserPoint);
        }

        public async Task<List<UserPoint>> GetAsync() =>
            await _userPointCollection.Find(_ => true).ToListAsync();

        public async Task<UserPoint?> GetAsync(string id) =>
            await _userPointCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<List<UserPoint>> GetAsync(bool approved) =>
            await _userPointCollection.Find(x => x.Approved == approved).ToListAsync();
        public async Task<List<UserPoint>> GetByUserIdAsync(string userId) =>
            await _userPointCollection.Find(x => x.UserId == userId).ToListAsync();
        public async Task RemoveAsync(string id) =>
            await _userPointCollection.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateAsync(UserPoint updatedUserPoint) =>
            await _userPointCollection.ReplaceOneAsync(x => x.Id == updatedUserPoint.Id, updatedUserPoint);
    }
}
