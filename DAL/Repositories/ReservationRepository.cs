using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(u => u.Tour).Include(u => u.ApplicationUser).Include(u => u.Contracts).ToListAsync();
        }
        public async override Task<Reservation> GetByIdAsync(int id) => await _dbSet.AsNoTracking()
            .Include(u => u.Tour)
            .Include(u => u.ApplicationUser)
            .Include(u => u.Contracts)
            .FirstOrDefaultAsync(a => a.Id == id);

    }
}
