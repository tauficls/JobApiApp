using UUIDNext;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobApiApp.JobApi.Models
{
    // public class JobPosition : BaseEntity
    public class JobPosition : BaseEntity
    {
        // Job Position example: BackEnd, FrontEnd, FullStack
        [Key]
        public Guid? Id { get; set; } = Uuid.NewDatabaseFriendly(Database.SQLite);
        // public Guid? Id { get; set; }
        // public int Id {get; set;}
        [StringLength(50)]
        public string? Code { get; set; }
        public string? Description { get; set; }
        // public int? ParentId { get; set; }
        // public int? JobTitleId { get; set; }
        // public int? OrganizationId { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? JobTitleId { get; set; }
        public Guid? OrganizationId { get; set; }
        // public ExpectedEmployees? ExpectedEmployees { get; set; }
        [JsonIgnore]
        [ForeignKey("ParentId")]
        public JobPosition? ParentJobPosition { get; set; }
        [JsonIgnore]
        public JobTitle? JobTitle { get; set; }
    }


}
