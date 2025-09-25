using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Learn.Csharp.AsyncAwait.Console
{
    public class ApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Async: Get all applications
        public async Task<List<Application>> GetAllAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        // Non-Async: Get all applications
        public List<Application> GetAll()
        {
            return _context.Applications.ToList();
        }

        // Async: Add application
        public async Task AddAsync(Application app)
        {
            await _context.Applications.AddAsync(app);
            await _context.SaveChangesAsync();
        }

        // Non-Async: Add application
        public void Add(Application app)
        {
            _context.Applications.Add(app);
            _context.SaveChanges();
        }

        // Async: Find by Id
        public async Task<Application?> FindByIdAsync(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        // Non-Async: Find by Id
        public Application? FindById(int id)
        {
            return _context.Applications.Find(id);
        }
    }
}