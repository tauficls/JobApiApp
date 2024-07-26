using HotChocolate.Subscriptions;
using JobApiApp.JobApi.Data;
using JobApiApp.JobApi.Models;
using JobApiApp.JobApi.Respositories;

namespace JobApiApp.JobApi.GraphQL.Mutation
{
    [ExtendObjectType("Mutation")]
    public class JobTitleMutation
    {
        public async Task<JobTitle> createJobTitle([Service] JobTitleRepository jobTitleRepository, string? code, string description, int level)
        {
            var newJobTitle = new JobTitle
            {
                Code = code,
                Description = description,
                Level = level
            };
            var createdJobTitle = await jobTitleRepository.CreateJobTitleAsync(newJobTitle);

            // await eventSender.SendAsync("JobTitleCreated", createdJobTitle);
            return createdJobTitle;
        }

        public async Task<JobTitle> updateJobTitleById([Service] JobTitleRepository jobTitleRepository, Guid id, string? code, string? description, int level)
        {
            var updateJobTitle = await jobTitleRepository.UpdateJobTitleByIdAsync(id, code, description, level);

            return updateJobTitle;
        }

        public string deleteJobTitleById([Service] JobTitleRepository jobTitleRepository, Guid id)
        {
            var deletedJobtitle = jobTitleRepository.DeleteJobTitleById(id);
            if (deletedJobtitle == null)
            {
                return $"id {id} not found";
            }
            return $"Success{deletedJobtitle.Id} has been deleted";
        }
    }
}