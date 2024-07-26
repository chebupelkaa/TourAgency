using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    internal class GroupMemberRepository : Repository<GroupMember>, IGroupMemberRepository
    {
        public GroupMemberRepository(ApplicationContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<GroupMember>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(u => u.Group).Include(u => u.ApplicationUser).ToListAsync();
        }
        public async override Task<GroupMember> GetByIdAsync(int id) => await _dbSet.AsNoTracking().Include(u => u.Group)
            .Include(u => u.ApplicationUser).FirstOrDefaultAsync(a => a.Id == id);
    
    
    }
}
