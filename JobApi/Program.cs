using JobApiApp.JobApi.Data;
using JobApiApp.JobApi.GraphQL.Query;
using  JobApiApp.JobApi.GraphQL.Mutation;
using JobApiApp.JobApi.Respositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<JobTitleRepository, JobTitleRepository>();
builder.Services.AddScoped<JobPositionRepository, JobPositionRepository>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDbContext>(option =>
option.UseSqlite(
    "Data Source=EmployeeDB.db"
));

// builder.Services
//     .AddDbContext<EmployeeDbContext>(option =>
//     option.UseInMemoryDatabase("EmployeeDB"));

builder.Services.AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
        .AddTypeExtension<JobTitleQuery>()
        .AddTypeExtension<JobPositionQuery>()
    .AddMutationType(m => m.Name("Mutation"))
        .AddTypeExtension<JobTitleMutation>()
        .AddTypeExtension<JobPositionMutation>();

    // .AddSubscriptionType<JobTitleSubscription>()
    // .AddInMemorySubscriptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWebSockets();
app.MapGraphQL();

app.MapControllers();

app.Run();
