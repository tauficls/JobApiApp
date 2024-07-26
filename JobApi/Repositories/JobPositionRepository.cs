using JobApiApp.JobApi.Data;
using JobApiApp.JobApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApiApp.JobApi.Respositories
{
    public class JobPositionRepository : IJobPositionRepository
    {
        // method create, retrive, update, delete
        private readonly EmployeeDbContext _context;

        public JobPositionRepository(EmployeeDbContext context) 
        {
            _context = context;
            // _context.Database.EnsureCreated();
        }
        // Create
        public async Task<JobPosition> CreateJobPositionAsync(JobPosition jobPosition)
        {
            await _context.AddAsync(jobPosition);
            await _context.SaveChangesAsync();

            return jobPosition;
        }


        // Retrieve
        public List<JobPosition> GetAllJobPositions()
        {
            return _context.JobPositions.Include(jp => jp.JobTitle).ToList();
        }

        public JobPosition? GetJobPositionById(Guid id)
        {
            var jobPosition = _context.JobPositions.Include(jp => jp.JobTitle).Where(j => j.Id == id).FirstOrDefault();
            if (jobPosition != null)
            {
                return jobPosition;
            }
            return null;
        }

        // Retrieve Async
        public async Task<List<JobPosition>> GetAllJobPositionsAsync()
        {
            return await _context.JobPositions.ToListAsync();
        }

        public async Task<JobPosition> GetJobPositionByIdAsync(Guid id)
        {
            return await _context.JobPositions.Where(j => j.Id == id).FirstAsync();
        }

        // Update
        public async Task<JobPosition> UpdateJobPositionByIdAsync(Guid id, string code, string description, Guid? jobTitleId)
        {
            var jobPosition = await _context.JobPositions.Where(j => j.Id == id).FirstOrDefaultAsync();
            if (jobPosition != null)
            {
                jobPosition.Code = code;
                jobPosition.Description = description;
                if (jobTitleId != null)
                {
                    jobPosition.JobTitleId = jobTitleId;
                }
                await _context.SaveChangesAsync();
            }

            return jobPosition;
        }
       
        // Delete
        public JobPosition DeleteJobPositionById(Guid id)
        {
            var jobPosition = _context.JobPositions.Where(j => j.Id == id).FirstOrDefault();
            if (jobPosition != null)
            {
                _context.JobPositions.Remove(jobPosition);
                _context.SaveChanges();
                return jobPosition;
            }
            return null;
        }

        

        

        

       

        // public async Task<JobPosition> UpdateJobPositionAsync(JobPosition jobPosition)
        // {
        //     throw new NotImplementedException();
        // }
    }
}