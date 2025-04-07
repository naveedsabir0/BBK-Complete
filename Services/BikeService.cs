using Microsoft.EntityFrameworkCore;
using MovieDatabaseBlazorServerApp.Data;
using MovieDatabaseBlazorServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabaseBlazorServerApp.Services
{
    public class BikeService
    {
        // The _context field holds the instance of the application database context.
        private readonly ApplicationDbContext _context;

        // The constructor initializes the BikeService with an instance of the application database context.
        public BikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves all bikes asynchronously along with associated cyclist information.
        public async Task<List<Bike>> GetAllBikesAsync()
        {
            return await _context.Bikes
                .Include(b => b.Cyclist)
                .ToListAsync();
        }

        // Retrieves a specific bike by its id asynchronously along with associated cyclist and repair information.
        public async Task<Bike> GetBikeByIdAsync(int id)
        {
            return await _context.Bikes
                .Include(b => b.Cyclist)
                .Include(b => b.Repairs)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // Adds a new bike asynchronously.
        public async Task AddBikeAsync(Bike bike)
        {
            _context.Bikes.Add(bike);
            await _context.SaveChangesAsync();
        }

        // Updates an existing bike asynchronously.
        public async Task UpdateBikeAsync(Bike bike)
        {
            _context.Entry(bike).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Deletes a bike asynchronously by its id.
        public async Task DeleteBikeAsync(int id)
        {
            var bike = await _context.Bikes.FindAsync(id);
            if (bike != null)
            {
                _context.Bikes.Remove(bike);
                await _context.SaveChangesAsync();
            }
        }

        // Filters a list of bikes based on search criteria.
        public List<Bike> FilterBikes(IEnumerable<Bike> bikes, string searchText)
        {
            // If the search text is empty, return all bikes.
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return bikes.ToList();
            }

            // Otherwise, filter the bikes based on the search text.
            return bikes.Where(b =>
                (!string.IsNullOrEmpty(b.Id.ToString()) && b.Id.ToString().Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(b.Make) && b.Make.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(b.Model) && b.Model.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                ).ToList();
        }

        // Retrieves repairs associated with a specific bike asynchronously.
        public async Task<List<Repair>> GetRepairsByBikeIdAsync(int bikeId)
        {
            return await _context.Repairs
                .Where(r => r.BikeID == bikeId)
                .ToListAsync();
        }

        // Retrieves a specific repair by its id asynchronously.
        public async Task<Repair> GetRepairByIdAsync(int id)
        {
            return await _context.Repairs.FindAsync(id);
        }

        // Adds or updates a repair asynchronously.
        public async Task AddOrUpdateRepairAsync(Repair repair)
        {
            if (repair.Id == 0)
            {
                _context.Repairs.Add(repair);
            }
            else
            {
                _context.Entry(repair).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
        public async Task<List<Cyclist>> GetAllCyclistsAsync()
        {
            return await _context.Cyclists.ToListAsync();
        }

        // Retrieves cyclist contact details associated with a specific bike asynchronously.
        public async Task<Cyclist> GetCyclistContactDetailsByBikeIdAsync(int bikeId)
        {
            var bike = await _context.Bikes
                .Include(b => b.Cyclist)
                .FirstOrDefaultAsync(b => b.Id == bikeId);

            return bike?.Cyclist;
        }
    }
}
