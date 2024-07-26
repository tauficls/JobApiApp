using HotChocolate.Subscriptions;
using JobApiApp.JobApi.Models;
using JobApiApp.JobApi.Respositories;

namespace JobApiApp.JobApi.GraphQL.Query
{
    [ExtendObjectType("Query")]
    public class JobPositionQuery
    {

        // Retrieve
        public List<JobPosition> GetAllJobPositions([Service] JobPositionRepository jobPositionRepository)
        {
            return jobPositionRepository.GetAllJobPositions();

        }

        public JobPosition GetJobPositionById([Service] JobPositionRepository jobPositionRepository, Guid id)
        {
            JobPosition jobPosition = jobPositionRepository.GetJobPositionById(id);
            return jobPosition;
        }

        // Retrive Async
        public async Task<List<JobPosition>> GetAllJobPositionsAsync([Service] JobPositionRepository jobPositionRepository)
        {
            return await jobPositionRepository.GetAllJobPositionsAsync();
        }

        // public async Task<JobPosition> GetJobPositionByIdAsync([Service] JobPositionRepository jobPositionRepository, [Service] ITopicEventSender eventSender, Guid id)
        // {
        //     JobPosition jobPosition = jobPositionRepository.GetJobPositionById(id);
        //     await eventSender.SendAsync("ReturnedJobPosition", jobPosition);
        //     return jobPosition;
        // }

        // public async Task<Product> GetProductbyId([Service] ProductRepository productRepository, 
        //     [Service] ITopicEventSender eventSender, int id)
        // {
        //     Product product = productRepository.GetProductbyId(id);
        //     await eventSender.SendAsync("ReturnedProduct", product);
        //     return product;
        // }
    }
}