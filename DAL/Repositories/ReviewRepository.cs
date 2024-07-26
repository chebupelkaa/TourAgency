using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(u => u.Tour).Include(u => u.ApplicationUser).ToListAsync();
        }
        public async override Task<Review> GetByIdAsync(int id) => await _dbSet.AsNoTracking()
            .Include(u => u.Tour)
            .Include(u => u.ApplicationUser)
            .FirstOrDefaultAsync(a => a.Id == id);


    }
}
