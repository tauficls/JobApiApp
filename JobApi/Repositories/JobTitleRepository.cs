using JobApiApp.JobApi.Data;
using JobApiApp.JobApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace JobApiApp.JobApi.Respositories
{
    public class JobTitleRepository : IJobTitleRepository
    {
        // method create, retrive, update, delete
        private readonly EmployeeDbContext _context;

        public JobTitleRepository(EmployeeDbContext context) 
        {
            _context = context;
            // _context.Database.EnsureCreated();
        }

        // Create
        public async Task<JobTitle> CreateJobTitleAsync(JobTitle jobTitle)
        {
            await _context.JobTitles.AddAsync(jobTitle);

            await _context.SaveChangesAsync();
            return jobTitle;
        }


        
        // Retrieve
        public List<JobTitle> GetAllJobTitles()
        {
            return _context.JobTitles.ToList();
        }

        public List<JobTitle> GetAllJobTitlesWithJobPosition()
        {
            return _context.JobTitles.Include(j => j.JobPositions).ToList();
        }

        public JobTitle? GetJobTitleById(Guid id)
        {
            var jobTitle = _context.JobTitles.Include(j => j.JobPositions).Where(j => j.Id == id).FirstOrDefault();
            if (jobTitle != null)
            {
                return jobTitle;
            }
            return null;
        }

        // Retrieve Async
        public async Task<List<JobTitle>> GetAllJobTitlesAsync()
        {
            return await _context.JobTitles.ToListAsync();
        }

        public async Task<JobTitle> GetJobTitleByIdAsync(Guid id)
        {
            return await _context.JobTitles.Where(j => j.Id == id).FirstAsync();
        }

        // Update
        public async Task<JobTitle> UpdateJobTitleByIdAsync(Guid id, string code, string description, int level)
        {
            var jobTitle = _context.JobTitles.Include(j => j.JobPositions).Where(j => j.Id == id).FirstOrDefault();
            if (jobTitle != null)
            {
                jobTitle.Code = code;
                jobTitle.Description = description;
                jobTitle.Level = level;

            }

            await _context.SaveChangesAsync();
            return jobTitle;
        }

        // Delete
        public JobTitle DeleteJobTitleById(Guid id)
        {
            var jobTitle = _context.JobTitles.Where(j => j.Id == id).FirstOrDefault();
            if (jobTitle != null)
            {
                _context.Remove(jobTitle);
                _context.SaveChanges();

                return jobTitle;
            }
            
            return null;
        }
    }
}