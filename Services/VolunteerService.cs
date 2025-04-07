using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseBlazorServerApp.Data;
using MovieDatabaseBlazorServerApp.Models;

namespace MovieDatabaseBlazorServerApp.Services
{
    public class VolunteerService
    {
        private readonly ApplicationDbContext _context;

        public VolunteerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Volunteer>> GetAllVolunteersAsync()
        {
            return await _context.Volunteers.ToListAsync();
        }

        public async Task<Volunteer> GetVolunteerByIdAsync(int id)
        {
            return await _context.Volunteers.FindAsync(id);
        }

        public async Task AddVolunteerAsync(Volunteer volunteer)
        {
            _context.Volunteers.Add(volunteer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVolunteerAsync(Volunteer volunteer)
        {
            _context.Entry(volunteer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVolunteerAsync(int id)
        {
            var volunteer = await _context.Volunteers.FindAsync(id);
            if (volunteer != null)
            {
                _context.Volunteers.Remove(volunteer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Dictionary<string, (int totalTime, double averageTime)>> GetRepairStatisticsForMonthAsync(DateTime month)
        {
            var repairRecords = await _context.RepairRecords
                .Include(rr => rr.Volunteer)
                .Where(rr => rr.RepairDate.Year == month.Year && rr.RepairDate.Month == month.Month)
                .ToListAsync();

            var statistics = repairRecords
                .GroupBy(rr => rr.Volunteer.Name)
                .ToDictionary(
                    g => g.Key,
                    g => (
                        totalTime: g.Sum(rr => rr.RepairTime),
                        averageTime: g.Average(rr => rr.RepairTime)
                    )
                );

            return statistics;
        }
    }

}
