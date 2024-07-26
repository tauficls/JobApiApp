// using JobAPi.GraphQL;
// using JobAPi.Respositories;
// using JobAPi.Models;
// using HotChocolate;
// using JobAPi.Database;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.HttpsPolicy;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using GraphQL.Query;

// namespace JobAPi
// {
//     public class Startup
//     {
//         private readonly string AllowedOrigin = "allowedOrigin";

//         public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;
//         }

//         public IConfiguration Configuration { get; }

//         // This method gets called by the runtime. Use this method to add services to the container.
//         public void ConfigureServices(IServiceCollection services)
//         {
//             services.AddDbContext<EmployeeDbContext>(options =>
//               options.UseSqlServer(Configuration.GetConnectionString("EmployeeDbContext")));
            
//             services.AddInMemorySubscriptions();

//             services
//                 .AddGraphQLServer()
//                 .AddQueryType<JobTitleQuery>()
//                 // .AddMutationType<Mutation>()
//                 .AddSubscriptionType<JobTitleSubscription>();            

//             services.AddScoped<JobTitleRepository, JobTitleRepository>();
//             // services.AddScoped<DepartmentRepository, DepartmentRepository>();

//             services.AddCors(option => {
//                 option.AddPolicy("allowedOrigin",
//                     builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
//                     );
//             });
//         }

//         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//         {
//             if (env.IsDevelopment())
//             {
//                 app.UseDeveloperExceptionPage();
//             }
//             app.UseCors(AllowedOrigin);
//             app.UseWebSockets();
//             app
//                 .UseRouting()
//                 .UseEndpoints(endpoints =>
//                 {
//                     endpoints.MapGraphQL();
//                 });           
//         }
//     }
// }