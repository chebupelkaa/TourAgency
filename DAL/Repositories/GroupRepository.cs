using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .Include(u => u.GroupMembers)
                .Include(u => u.Tour)
                .ToListAsync();
        }
        public async override Task<Group> GetByIdAsync(int id) => await _dbSet.AsNoTracking()
            .Include(u => u.GroupMembers).ThenInclude(s=>s.ApplicationUser)
            .Include(u => u.Tour)
            .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Group> GetByTourId(int id)
        {
            return await _dbSet.AsNoTracking()
            .Include(u => u.GroupMembers)
            .Include(u => u.Tour)
            .FirstOrDefaultAsync(a => a.TourId == id);

        }
    }
}
