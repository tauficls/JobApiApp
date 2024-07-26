using JobApiApp.JobApi.Models;

namespace JobApiApp.JobApi.Respositories
{
    public interface IJobTitleRepository
    {
        
        // Retrieve
        List<JobTitle> GetAllJobTitles();
        List<JobTitle> GetAllJobTitlesWithJobPosition();

        JobTitle? GetJobTitleById(Guid id);

        // Retrieve Async
        Task<List<JobTitle>> GetAllJobTitlesAsync();
		Task<JobTitle> GetJobTitleByIdAsync(Guid id);
        

        // // Create
		Task<JobTitle> CreateJobTitleAsync(JobTitle jobTitle);
        
        // // Update
        Task<JobTitle> UpdateJobTitleByIdAsync(Guid id, string code, string description, int level);

        // // Delete
        JobTitle DeleteJobTitleById(Guid id);


    }
}