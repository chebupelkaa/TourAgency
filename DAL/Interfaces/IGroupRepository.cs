using DAL.Entities;
using DAL.interfaces;


namespace DAL.Interfaces
{
    public interface IGroupRepository:IRepository<Group>
    {
        Task<Group> GetByTourId(int id);
    }
}
