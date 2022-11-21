using MallconomyCase.Models;
using System.Linq.Expressions;

namespace MallconomyCase.Helper
{
    public class HelperFunctions
    {
        public static User UserPointToUser(UserPoint thirdPrizeUserPoint, int rank, string award)
        {
            User thirdPrizeUser = new User();
            thirdPrizeUser.Id = thirdPrizeUserPoint.UserId;
            thirdPrizeUser.Rank = rank;
            thirdPrizeUser.Award = award;
            thirdPrizeUser.TotalPoint = thirdPrizeUserPoint.Point;

            return thirdPrizeUser;
        }
        public static string RankToAward(int rank)
        {
            string award;
            switch (rank)
            {
                case 1:
                    award = "First Prize";    
                    break;
                case 2:
                    award = "Second Prize";
                    break;
                case 3:
                    award = "Third Prize";
                    break;
                case > 3 and <= 100:
                    award = "25$ and 12.5$ Award";
                    break;
                case > 100 and <= 1000:
                    award = "12.5$ Award";
                    break;
                default:
                    award = "0";
                    break;
            }
            return award;
        }
        public static DateTime RandomDate()
        {
            Random gen = new Random();
            DateTime start = DateTime.Today.AddYears(-1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
