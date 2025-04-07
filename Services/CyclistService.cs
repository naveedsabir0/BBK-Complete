using Microsoft.EntityFrameworkCore;
using MovieDatabaseBlazorServerApp.Data;
using MovieDatabaseBlazorServerApp.Models;

namespace MovieDatabaseBlazorServerApp.Services
{
    public class CyclistService
    {
        private readonly ApplicationDbContext _context;

        public CyclistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cyclist>> GetAllCyclistsAsync()
        {
            return await _context.Cyclists.ToListAsync();
        }

        public async Task<Cyclist> GetCyclistByIdAsync(int id)
        {
            return await _context.Cyclists
                                 .Include(c => c.Bikes) // Include related bikes
                                 .ThenInclude(b => b.Repairs) // Include repairs for each bike
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCyclistAsync(Cyclist cyclist)
        {
            _context.Cyclists.Add(cyclist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCyclistAsync(Cyclist cyclist)
        {
            _context.Entry(cyclist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCyclistAsync(int id)
        {
            var cyclist = await _context.Cyclists.FindAsync(id);
            if (cyclist != null)
            {
                _context.Cyclists.Remove(cyclist);
                await _context.SaveChangesAsync();
            }
        }

        public List<Cyclist> FilterCyclists(IEnumerable<Cyclist> cyclists, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return cyclists.ToList();
            }

            return cyclists.Where(c =>
                (!string.IsNullOrEmpty(c.Name) && c.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(c.Email) && c.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(c.Phone) && c.Phone.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }
    }
}
