namespace MallconomyCase.Models
{
    public class UserPointDatabaseSettings : IUserPointDatabaseSettings
    {
        public string UserPointCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
