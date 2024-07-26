using UUIDNext;
using System.Data.SQLite;

namespace JobApiApp.JobApi.Models
{
    public class ExpectedEmployees 
    {
        public Guid? Id { get; set; } = Uuid.NewDatabaseFriendly(Database.SQLite);
        private string? name;

    }
}