using Microsoft.EntityFrameworkCore;
using MovieDatabaseBlazorServerApp.Data;
using MovieDatabaseBlazorServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabaseBlazorServerApp.Services
{
    public class PartService
    {
        private readonly ApplicationDbContext _context;

        public PartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Part>> GetAllPartsAsync()
        {
            return await _context.Parts.ToListAsync();
        }

        public async Task<Part> GetPartByIdAsync(int id)
        {
            return await _context.Parts.FindAsync(id);
        }

        public async Task AddPartAsync(Part part)
        {
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePartAsync(Part part)
        {
            _context.Entry(part).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePartAsync(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part != null)
            {
                _context.Parts.Remove(part);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(List<Part> Parts, decimal TotalCost)> GetPartsUsedForMonthAsync(DateTime month)
        {
            var startDate = new DateTime(month.Year, month.Month, 1);
            var endDate = startDate.AddMonths(1);

            var partsUsedInMonth = await _context.Repairs
                .Where(r => r.Date >= startDate && r.Date < endDate)
                .SelectMany(r => r.Parts)
                .ToListAsync();

            var totalCost = partsUsedInMonth.Sum(p => p.Cost);

            return (partsUsedInMonth, totalCost);
        }

        public async Task<(int TotalPartsUsed, Dictionary<string, int> PartsCount)> GetPartsUsageForMonthAsync(DateTime month)
        {
            var startDate = new DateTime(month.Year, month.Month, 1);
            var endDate = startDate.AddMonths(1);

            var partsUsedInMonth = await _context.Repairs
                .Where(r => r.Date >= startDate && r.Date < endDate)
                .SelectMany(r => r.Parts)
                .ToListAsync();

            var totalPartsUsed = partsUsedInMonth.Count;

            var partsCount = partsUsedInMonth
                .GroupBy(p => p.Name)
                .ToDictionary(g => g.Key, g => g.Count());

            return (totalPartsUsed, partsCount);
        }
    }
}
