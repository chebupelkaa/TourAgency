using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    //internal class UserRepository : Repository<ApplicationUser>, IUserRepository
    //{
    //    public UserRepository(ApplicationContext context) : base(context)
    //    {
    //    }
    //    public override async Task<IEnumerable<ApplicationUser>> GetAllAsync()
    //    {
    //        return await _dbSet.AsNoTracking().Include(u => u.GroupMembers).Include(u => u.Reviews).Include(u => u.Reservations).ToListAsync();//сделашеь для каждого репозитория
    //    }
    //    public async override Task<ApplicationUser> GetByIdAsync(int id) => await _dbSet.AsNoTracking().Include(u => u.GroupMembers).Include(u => u.Reviews).Include(u => u.Reservations).FirstOrDefaultAsync(a => a.Id == id);
    //}
}
