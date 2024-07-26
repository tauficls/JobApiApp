using JobApiApp.JobApi.Models;
using UUIDNext;


namespace JobApiApp.JobApi.Respositories
{
    public interface IJobPositionRepository
    {
        // Retrieve
        List<JobPosition> GetAllJobPositions();
        JobPosition? GetJobPositionById(Guid id);
        
        // Retrieve Async
        Task<List<JobPosition>> GetAllJobPositionsAsync();
		Task<JobPosition> GetJobPositionByIdAsync(Guid id);

        // Create
        // JobPosition CreateJobPosition(JobPosition jobPosition);
        // Create Async
		Task<JobPosition> CreateJobPositionAsync(JobPosition jobPosition);
        
        // // Update
        // JobPosition UpdateJobPositionById(JobPosition jobPosition);

        // Update Async
        Task<JobPosition> UpdateJobPositionByIdAsync(Guid id, string code, string description, Guid? jobTitleId);
        // Delete
        JobPosition DeleteJobPositionById(Guid id);

        // Delete Async
        // Task<JobPosition> DeleteJobPositionAsync(Guid id);


    }
}