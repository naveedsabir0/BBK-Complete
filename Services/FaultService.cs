using Microsoft.EntityFrameworkCore;
using MovieDatabaseBlazorServerApp.Data;
using MovieDatabaseBlazorServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabaseBlazorServerApp.Services
{
    public class FaultService
    {
        private readonly ApplicationDbContext _context;

        public FaultService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fault>> GetAllFaultsAsync()
        {
            return await _context.Faults.ToListAsync();
        }

        public async Task<Fault> GetFaultByIdAsync(int id)
        {
            return await _context.Faults.FindAsync(id);
        }

        public async Task AddFaultAsync(Fault fault)
        {
            _context.Faults.Add(fault);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFaultAsync(Fault fault)
        {
            _context.Entry(fault).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFaultAsync(int id)
        {
            var fault = await _context.Faults.FindAsync(id);
            if (fault != null)
            {
                _context.Faults.Remove(fault);
                await _context.SaveChangesAsync();
            }
        }
    }
}
