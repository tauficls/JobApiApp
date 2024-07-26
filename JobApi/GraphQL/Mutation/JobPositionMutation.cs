using System.Data.Odbc;
using JobApiApp.JobApi.Models;
using JobApiApp.JobApi.Respositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace JobApiApp.JobApi.GraphQL.Mutation
{
    [ExtendObjectType("Mutation")]
    public class JobPositionMutation
    {
        public async Task<JobPosition> createJobPosition([Service] JobPositionRepository jobPositionRepository, string code, string description, Guid jobTitleId)
        {
            var newJobPosition = new JobPosition
            {
                Code = code,
                Description = description,
                JobTitleId = jobTitleId

            };
            var createdJobPosition = await jobPositionRepository.CreateJobPositionAsync(newJobPosition);
            return newJobPosition;
        }


        public async Task<JobPosition> updateJobPositionById([Service] JobPositionRepository jobPositionRepository, Guid id, string code, string description, Guid jobTitleId)
        {
            var updateJobPosition = await jobPositionRepository.UpdateJobPositionByIdAsync(id, code, description, jobTitleId);

            return updateJobPosition;
        }

        public string deleteJobPositionById([Service] JobPositionRepository jobPositionRepository, Guid id)
        {
            var deletedJobPosition = jobPositionRepository.DeleteJobPositionById(id);

            if (deletedJobPosition != null)
            {
                return $"Success {id} deleted";
            }

            return $"Id {id} Not Found";
        }
    }
}