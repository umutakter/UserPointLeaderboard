namespace MallconomyCase.Models
{
    public interface IUserPointDatabaseSettings
    {
        string UserPointCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
