using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseBlazorServerApp.Data;
using MovieDatabaseBlazorServerApp.Models;

namespace MovieDatabaseBlazorServerApp.Services
{
    public class RepairService
    {
        private readonly ApplicationDbContext _context;

        public RepairService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Repair>> GetAllRepairsAsync()
        {
            return await _context.Repairs.ToListAsync();
        }

        public async Task<Repair> GetRepairByIdAsync(int id)
        {
            return await _context.Repairs.FindAsync(id);
        }

        public async Task AddRepairAsync(Repair repair)
        {
            _context.Repairs.Add(repair);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRepairAsync(Repair repair)
        {
            _context.Entry(repair).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRepairAsync(int id)
        {
            var repair = await _context.Repairs.FindAsync(id);
            if (repair != null)
            {
                _context.Repairs.Remove(repair);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RecordBikeRepairDetailsAsync(int bikeId, DateTime repairDate, string repairDetails, List<Part> partsUsed)
        {
            decimal totalCost = partsUsed.Sum(p => p.Cost);

            var repair = new Repair
            {
                BikeID = bikeId,
                Date = repairDate,
                Title = repairDetails,
                Parts = partsUsed,
                TotalCost = totalCost
            };

            _context.Repairs.Add(repair);
            await _context.SaveChangesAsync();
        }

        public async Task BookBikeForRepairAsync(int bikeId, int cyclistId, List<string> faults)
        {
            var bike = await _context.Bikes.FindAsync(bikeId);
            var cyclist = await _context.Cyclists.FindAsync(cyclistId);

            if (bike != null && cyclist != null && faults != null && faults.Any())
            {
                var repairDetails = string.Join(", ", faults);
                var repairDate = DateTime.Now;

                var repair = new Repair
                {
                    BikeID = bikeId,
                    Date = repairDate,
                    Title = $"Bike Repair for {cyclist.Name}",
                };

                _context.Repairs.Add(repair);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Invalid bike, cyclist, or faults.");
            }
        }

        public async Task<RepairStats> GetRepairStatsForMonthAsync(DateTime month)
        {
            var repairsInMonth = await _context.Repairs
                .Where(r => r.Date.Year == month.Year && r.Date.Month == month.Month)
                .ToListAsync();

            int repairCount = repairsInMonth.Count;
            decimal averageCost = repairCount > 0 ? repairsInMonth.Average(r => r.TotalCost) : 0;

            return new RepairStats
            {
                RepairCount = repairCount,
                AverageCost = averageCost
            };
        }
    }

    public class RepairStats
    {
        public int RepairCount { get; set; }
        public decimal AverageCost { get; set; }
    }
}
