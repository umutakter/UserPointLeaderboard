using MallconomyCase.IRepository;
using MallconomyCase.Models;
using MallconomyCase.Helper;
using Microsoft.AspNetCore.Mvc;

namespace MallconomyCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPointController : ControllerBase
    {
        private readonly IUserPointRepository _userPointService;

        public UserPointController(IUserPointRepository _userPointService)
        {
            this._userPointService = _userPointService;
        }

        [HttpPost("LeaderBoardAllTime")]
        public async Task<IActionResult> LeaderBoardAllTime()
        {
            IEnumerable<UserPoint> userPoints = await _userPointService.GetAsync(true);
            var sortedUsers = userPoints
                .Where(x => x.Approved == true)
                .GroupBy(x => x.UserId)
                .Select(x =>new UserPoint
                    {
                        Id = x.First().Id,
                        Point = x.Sum(x => x.Point),
                        UserId = x.First().UserId
                    })
                .ToList()
                .OrderByDescending(x => x.Point);

            List<User> users = new List<User>();

            var firstPrizeUserPoint = sortedUsers.Take(1).FirstOrDefault();
            users.Add(HelperFunctions.UserPointToUser(firstPrizeUserPoint, 1, "First Prize"));

            var secondPrizeUserPoint = sortedUsers.Skip(1).Take(1).FirstOrDefault();
            users.Add(HelperFunctions.UserPointToUser(secondPrizeUserPoint, 2, "Second Prize"));

            var thirdPrizeUserPoint = sortedUsers.Skip(2).Take(1).FirstOrDefault();
            users.Add(HelperFunctions.UserPointToUser(thirdPrizeUserPoint, 3, "Third Prize"));

            int rank = 3;

            var topHundredUserPoint = sortedUsers.Skip(3).Take(97);
            foreach(var userPoint in topHundredUserPoint)
            {
                rank++;
                users.Add(HelperFunctions.UserPointToUser(userPoint, rank, "25$ and 12.5$ Award"));

            }

            var topThousandUserPoint = sortedUsers.Skip(100).Take(900);
            foreach (var userPoint in topThousandUserPoint)
            {
                rank++;
                users.Add(HelperFunctions.UserPointToUser(userPoint, rank, "12.5$ Award"));
            }
            return Ok(users);
        }

        [HttpPost("LeaderBoardSelectedMonth")]
        public async Task<IActionResult> LeaderBoardSelectedMonth(int month)
        {
            if (month < 1 && month > 12)
            {
                BadRequest("Listelenmesini istediğiniz ay bilgisi yanlış!");
            }

            IEnumerable<UserPoint> userPoints = await _userPointService.GetAsync(true);
            var sortedUsers = userPoints
                .Where(x => x.Approved == true && x.Date.Month == month)
                .GroupBy(x => x.UserId)
                .Select(x => new UserPoint
                {
                    Id = x.First().Id,
                    Point = x.Sum(x => x.Point),
                    UserId = x.First().UserId,
                })
                .ToList()
                .OrderByDescending(x => x.Point);

            
            return Ok(sortedUsers);
        }

        [HttpPost("SelectedUserPoints")]
        public async Task<IActionResult> SelectedUserPoints(string userId)
        {
            List<UserPoint> userPoints = await _userPointService.GetByUserIdAsync(userId);

            if (userPoints == null)
            {
                return BadRequest("Girdiğiniz ID'ye ait kullanici kaydı bulunamamıştır...");
            }

            return Ok(userPoints);
        }

        [HttpPost("LeaderBoardSelectedUser")]
        public async Task<IActionResult> LeaderBoardSelectedUser(string userId)
        {
            IEnumerable<UserPoint> userPoints = await _userPointService.GetAsync(true);
            var sortedUsers = userPoints
                .Where(x => x.Approved == true)
                .GroupBy(x => x.UserId)
                .Select(x => new UserPoint
                {
                    Id = x.First().Id,
                    Point = x.Sum(x => x.Point),
                    UserId = x.First().UserId
                })
                .ToList()
                .OrderByDescending(x => x.Point);

            int index = sortedUsers.ToList().FindIndex(a => a.UserId == userId);
            if (index<0)
            {
                return BadRequest("Girdiğiniz ID'ye ait kullanici kaydı bulunamamıştır...");
            }
            var user = HelperFunctions.UserPointToUser(sortedUsers.ToList()[index], index + 1, HelperFunctions.RankToAward(index + 1));
            return Ok(user);
        }


        #region Add Date
        /*[HttpPost("addRandomDate")]
        public async Task<IActionResult> AddRandomDate()
        {
            List<UserPoint> userPoints = await _userPointService.GetAsync();
            foreach (var userPoint in userPoints)
            {
                userPoint.Date = HelperFunctions.RandomDate();
                await _userPointService.UpdateAsync(userPoint);
            }
            return Ok();
        }
        
        */
        #endregion
    }
}
