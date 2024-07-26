using JobApiApp.JobApi.Models;
using JobApiApp.JobApi.Data;
using JobApiApp.JobApi.GraphQL.Query;
using JobApiApp.JobApi.GraphQL.Mutation;
using JobApiApp.JobApi.Respositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using System;
using Newtonsoft.Json.Linq;
// using Xunit;

namespace JobApiTest
{
    public class JobTitleTest
    {
        [Fact]
        public async Task getAllJobTitle()
        {
            IRequestExecutor executor = await new ServiceCollection()
                .AddScoped<JobTitleRepository, JobTitleRepository>()
                .AddScoped<JobPositionRepository, JobPositionRepository>()
                .AddDbContext<EmployeeDbContext>(options => options
                .UseInMemoryDatabase("Data Source=EmployeeDB.db"))
                .AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                    .AddTypeExtension<JobTitleQuery>()
                    // .AddTypeExtension<JobPositionQuery>()
                .AddMutationType(m => m.Name("Mutation"))
                    .AddTypeExtension<JobTitleMutation>()
                    // .AddTypeExtension<JobPositionMutation>();
                .BuildRequestExecutorAsync();


            // act

            // Create

//             createJobTitle()
//             public async Task<JobTitle> createJobTitle([Service] JobTitleRepository jobTitleRepository, string? code, string description, int level)
// public async Task<JobTitle> updateJobTitleById([Service] JobTitleRepository jobTitleRepository, Guid id, string? code, string? description, int level)
//         {
//             var updateJobTitle = await jobTitleRepository.UpdateJobTitleByIdAsync(id, code, description, level);

//             return updateJobTitle;
//         }

//         public string deleteJobTitleById([Service] JobTitleRepository jobTitleRepository, Guid id)
            int code = 101;
            int level = 4;
            string description = "Lead";

            string query = @"
                mutation {
                    createJobTitle(code: ""101"", description: ""Lead"", level: 4) {
                        code
                        description
                        id
                        isUsed
                        level
                    }
                }
            ";
            
            IExecutionResult result = await executor.ExecuteAsync(query);
            
            JObject jobj = JObject.Parse(result.ToString());

            // assert
            result.ToJson().MatchSnapshot();


            Guid id = new Guid(jobj["data"]["createJobTitle"]["id"]?.ToString());
            Console.WriteLine(id);
            

        }
    }
}