using UUIDNext;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobApiApp.JobApi.Models
{
    // public class JobTitle : BaseEntity
    public class JobTitle : BaseEntity
    {
        // Example of title Lead, Senior, Junior Engineer
        [Key]
        // public Guid? Id { get; set; }
        // public int Id { get; set; }
        public Guid? Id { get; set; } = Uuid.NewDatabaseFriendly(Database.SQLite);
        [StringLength(50)]
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int Level { get; set; }

        [NotMapped]
        public bool? isUsed { get; set; }

        // A single JobTitle can have many JobPosition such as Junior FullStack, Senior FullStack
        [JsonIgnore]
        public ICollection<JobPosition>? JobPositions { get; set; }

        public void AddJobPosition(JobPosition jobPosition)
        {
            JobPositions.Add(jobPosition);
        }
    }
}

