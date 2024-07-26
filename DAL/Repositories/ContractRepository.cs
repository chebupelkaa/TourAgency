
using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class ContractRepository :Repository<Contract>, IContractRepository
    {
        public ContractRepository(ApplicationContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Contract>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(u => u.Reservation).ToListAsync();
        }
        public async override Task<Contract> GetByIdAsync(int id) => await _dbSet.AsNoTracking().Include(u => u.Reservation).FirstOrDefaultAsync(a => a.Id == id);
    }
}
