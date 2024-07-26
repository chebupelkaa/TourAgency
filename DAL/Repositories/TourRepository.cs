using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class TourRepository : Repository<Tour>, ITourRepository
    {
        public TourRepository(ApplicationContext context) : base(context)
        {
        }
        
        public override async Task<IEnumerable<Tour>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(t => t.Groups)
                .Include(t => t.Reviews)
                .Include(t => t.Reservations).ToListAsync();
        }

        public async override Task<Tour> GetByIdAsync(int id) => await _dbSet.AsNoTracking().Include(t=>t.Groups).Include(t => t.Reviews).Include(t => t.Reservations).FirstOrDefaultAsync(a => a.Id == id);
    }
}
