using BLL.DTO;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IGroupService : IService<GroupDTO>
    {
        public Task<IEnumerable<GroupDTO>> GetAllAsyncByTourId(int tourId);
        public Task AddToGroup(int tourId, string userId);
    }
}
