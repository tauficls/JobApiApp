using System.Reflection.Metadata;
using JobApiApp.JobApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApiApp.JobApi.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<JobTitle>().OwnsMany(jobtitle => jobtitle.JobPositions).HasData(
                new JobPosition 
                {
                    Code = "101",
                    Description = "BackEnd",
                    JobTitleId = new Guid("0190e8dd-0225-725f-8099-93fb2b33a906")
                },
                new JobPosition 
                {
                    Code = "102",
                    Description = "BackEnd",
                    JobTitleId = new Guid("0190e8dd-0225-7260-800e-9118cdb9d783")
                },
                new JobPosition 
                {
                    Code = "103",
                    Description = "BackEnd",
                    JobTitleId = new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b")
                },
                new JobPosition 
                {
                    Code = "201",
                    Description = "FrontEnd",
                    JobTitleId = new Guid("0190e8dd-0225-725f-8099-93fb2b33a906")
                },
                new JobPosition 
                 {
                    Code = "202",
                    Description = "FrontEnd",
                    JobTitleId = new Guid("0190e8dd-0225-7260-800e-9118cdb9d783")
                },
                new JobPosition 
                 {
                    Code = "203",
                    Description = "FrontEnd",
                    JobTitleId = new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b")
                },
                new JobPosition 
                {
                    Code = "301",
                    Description = "FullStack",
                    JobTitleId = new Guid("0190e8dd-0225-725f-8099-93fb2b33a906")
                },
                new JobPosition 
                {
                    Code = "302",
                    Description = "FullStack",
                    JobTitleId = new Guid("0190e8dd-0225-7260-800e-9118cdb9d783")
                },
                new JobPosition 
                {
                    Code = "303",
                    Description = "FullStack",
                    JobTitleId = new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b")
                }

            );
            */
            modelBuilder.Entity<JobTitle>().HasData
            (
                new JobTitle
                {
                    Code = "123",
                    Description = "Junior",
                    Level = 1,
                    Id = new Guid("0190e8dd-0225-725f-8099-93fb2b33a906")
                },
                new JobTitle
                {
                    Code = "100",
                    Description = "Senior",
                    Level = 2,
                    Id = new Guid("0190e8dd-0225-7260-800e-9118cdb9d783")

                },
                new JobTitle
                {
                    Code = "200",
                    Description = "Lead",
                    Level = 3,
                    Id = new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b")
                }
            );
            
            modelBuilder.Entity<JobPosition>().HasData(
                new JobPosition 
                {
                    Code = "101",
                    Description = "BackEnd",
                    JobTitleId = new Guid("0190e8dd-0225-725f-8099-93fb2b33a906")
                },
                new JobPosition 
                {
                    Code = "102",
                    Description = "BackEnd",
                    JobTitleId = new Guid("0190e8dd-0225-7260-800e-9118cdb9d783")
                },
                new JobPosition 
                {
                    Code = "103",
                    Description = "BackEnd",
                    JobTitleId = new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b")
                },
                new JobPosition 
                {
                    Code = "201",
                    Description = "FrontEnd",
                    JobTitleId = new Guid("0190e8dd-0225-725f-8099-93fb2b33a906")
                },
                new JobPosition 
                 {
                    Code = "202",
                    Description = "FrontEnd",
                    JobTitleId = new Guid("0190e8dd-0225-7260-800e-9118cdb9d783")
                },
                new JobPosition 
                 {
                    Code = "203",
                    Description = "FrontEnd",
                    JobTitleId = new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b")
                },
                new JobPosition 
                {
                    Code = "301",
                    Description = "FullStack",
                    JobTitleId = new Guid("0190e8dd-0225-725f-8099-93fb2b33a906")
                },
                new JobPosition 
                {
                    Code = "302",
                    Description = "FullStack",
                    JobTitleId = new Guid("0190e8dd-0225-7260-800e-9118cdb9d783")
                },
                new JobPosition 
                {
                    Code = "303",
                    Description = "FullStack",
                    JobTitleId = new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b")
                }

            );
        }

        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
    }
}
