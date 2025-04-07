using DotLiquid;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseBlazorServerApp.Data;
using MovieDatabaseBlazorServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabaseBlazorServerApp.Services
{
    public class ClassService
    {
        private readonly ApplicationDbContext _context;

        public ClassService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetAllClassesAsync()
        {
            return await _context.Classes
                .Include(c => c.Cyclists)
                .Include(c => c.Volunteer)
                .ToListAsync();
        }

        public async Task<Class> GetClassByIdAsync(int id)
        {
            return await _context.Classes
                .Include(c => c.Cyclists)
                .Include(c => c.Volunteer)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddClassAsync(Class classObj)
        {
            _context.Classes.Add(classObj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClassAsync(Class classObj)
        {
            var existingClass = await _context.Classes
                .Include(c => c.Cyclists)
                .FirstOrDefaultAsync(c => c.Id == classObj.Id);

            if (existingClass != null)
            {
                // Update scalar properties
                _context.Entry(existingClass).CurrentValues.SetValues(classObj);

                // Compare and update cyclists
                foreach (var cyclist in classObj.Cyclists)
                {
                    // Add new cyclists
                    if (!existingClass.Cyclists.Any(c => c.Id == cyclist.Id))
                    {
                        existingClass.Cyclists.Add(await _context.Cyclists.FindAsync(cyclist.Id));
                    }
                }

                // Remove cyclists not in the updated list
                foreach (var cyclist in existingClass.Cyclists.ToList())
                {
                    if (!classObj.Cyclists.Any(c => c.Id == cyclist.Id))
                    {
                        existingClass.Cyclists.Remove(cyclist);
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetClassAttendanceCountAsync(int classId)
        {
            var classObj = await _context.Classes.Include(c => c.Cyclists).FirstOrDefaultAsync(c => c.Id == classId);
            if (classObj != null)
            {
                return classObj.Cyclists.Count;
            }
            return 0;
        }

        public async Task DeleteClassAsync(int id)
        {
            var classObj = await _context.Classes.FindAsync(id);
            if (classObj != null)
            {
                _context.Classes.Remove(classObj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Class>> GetClassesByMonthAsync(int month, int year)
        {
            return await _context.Classes
                .Where(c => c.Date.Month == month && c.Date.Year == year)
                .Include(c => c.Cyclists)
                .Include(c => c.Volunteer)
                .ToListAsync();
        }

        public async Task<List<Class>> GetClassesByVolunteerAsync(string volunteerName)
        {
            return await _context.Classes
                .Where(c => c.Volunteer.Forename.Contains(volunteerName) || c.Volunteer.Surname.Contains(volunteerName))
                .Include(c => c.Cyclists)
                .Include(c => c.Volunteer)
                .ToListAsync();
        }

        public async Task<List<ClassAttendance>> GetClassAttendanceCountByMonthAsync(int month, int year, bool groupByVolunteer = false)
        {
            IQueryable<Class> query = _context.Classes.Include(c => c.Cyclists).Include(c => c.Volunteer);

            // Filter by month and year
            query = query.Where(c => c.Date.Month == month && c.Date.Year == year);

            // Group by volunteer if required
            if (groupByVolunteer)
            {
                var classAttendanceCountByVolunteer = await query
                    .GroupBy(c => c.Volunteer)
                    .Select(g => new ClassAttendance
                    {
                        VolunteerName = g.Key != null ? g.Key.Name : "Unknown",
                        NumberOfCyclists = g.Sum(x => x.Cyclists.Count)
                    })
                    .ToListAsync();

                return classAttendanceCountByVolunteer;
            }
            else
            {
                var classAttendanceCount = await query
                    .Select(c => new ClassAttendance
                    {
                        ClassTitle = c.Title,
                        NumberOfCyclists = c.Cyclists.Count
                    })
                    .ToListAsync();

                return classAttendanceCount;
            }
        }
        public async Task<List<Volunteer>> GetAllVolunteersAsync()
        {
            // Assuming you have a database context named "dbContext" to interact with your database
            var volunteers = await _context.Volunteers.ToListAsync();
            return volunteers;
        }

        public async Task<List<CyclistAttendance>> GetCyclistAttendanceAsync(int month, int year, int volunteerId)
        {
            IQueryable<Class> query = _context.Classes.Include(c => c.Cyclists).Include(c => c.Volunteer);

            if (month != 0 && year != 0)
            {
                query = query.Where(c => c.Date.Month == month && c.Date.Year == year);
            }

            if (volunteerId != 0)
            {
                query = query.Where(c => c.VolunteerId == volunteerId);
            }

            var cyclistAttendance = await query
                .SelectMany(c => c.Cyclists, (cls, cyclist) => new { Class = cls, Cyclist = cyclist })
                .Select(x => new CyclistAttendance
                {
                    CyclistID = x.Cyclist.Id,
                    CyclistName = x.Cyclist.Name,
                    DateOfClass = x.Class.Date,
                    VolunteerName = x.Class.Volunteer != null ? x.Class.Volunteer.Name : ""
                })
                .ToListAsync();

            return cyclistAttendance;
        }

        public async Task<Volunteer> GetVolunteerDetailsAsync(string volunteerName)
        {
            // Implement the logic to retrieve volunteer details based on the volunteerName
            // For example, you might fetch the details from a database
            // Replace this with your actual implementation

            // Sample implementation
            var volunteerDetails = await _context.Volunteers.FirstOrDefaultAsync(v => v.Name == volunteerName);
            return volunteerDetails;
        }
        public async Task<List<Class>> GetClassesByVolunteerAndMonthAsync(string volunteerName, int month, int year)
        {
            return await _context.Classes
                .Where(c => c.Volunteer.Forename.Contains(volunteerName) || c.Volunteer.Surname.Contains(volunteerName))
                .Where(c => c.Date.Month == month && c.Date.Year == year)
                .Include(c => c.Cyclists)
                .Include(c => c.Volunteer)
                .ToListAsync();
        }
    }
}

