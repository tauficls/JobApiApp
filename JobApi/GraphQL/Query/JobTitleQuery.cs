using HotChocolate;
using HotChocolate.Subscriptions;
using System.Collections.Generic;
using JobApiApp.JobApi.Models;
using JobApiApp.JobApi.Respositories;
using System.Threading.Tasks;
using JobApiApp.JobApi.Data;

namespace JobApiApp.JobApi.GraphQL.Query
{
    [ExtendObjectType("Query")]
    public class JobTitleQuery
    {
        // Retrieve
        public List<JobTitle> GetAllJobTitles([Service] JobTitleRepository jobTitleRepository)
        {
            return jobTitleRepository.GetAllJobTitles();

        }

        public List<JobTitle> GetAllJobTitlesWithJobPositions([Service] JobTitleRepository jobTitleRepository)
        {
            return jobTitleRepository.GetAllJobTitlesWithJobPosition();
        }

        public JobTitle GetJobTitleById([Service] JobTitleRepository jobTitleRepository, Guid id)
        {
            JobTitle jobTitle = jobTitleRepository.GetJobTitleById(id);
            // await eventSender.SendAsync("ReturnedJobTitle", jobTitle);
            return jobTitle;
        }

        
        public JobTitle GetJobTitleDummy()
        {
            return new JobTitle {
                Code = "301",
                Description = "Software Engineer",
                Level = 1
            };
        }

        // Retrieve Async
        // public async Task<List<JobTitle>> GetAllTitlesAsync([Service] JobTitleRepository jobTitleRepository)
        // {
        //     return await jobTitleRepository,
        // }
        

        // public async Task<JobTitle> GetTitleById([Service] JobTitleRepository jobTitleRepository, [Service]ITopicEventSender eventSender, Guid id)
        // {
        //     JobTitle jobTitle = jobTitleRepository.GetJobTitleById(id);
        //     await eventSender.SendAsync("ReturnedJobTitle", jobTitle);
        //     return jobTitle;
        // }
        // public async Task<List<JobTitle>> GetAllJobTitles([Service] JobTitleRepository jobTitleRepository)
        // {
        //     return await jobTitleRepository.GetJobTitleAsync();
        // }
        
    }
}