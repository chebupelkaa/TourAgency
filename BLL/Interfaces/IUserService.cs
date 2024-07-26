using BLL.DTO;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserDTO>
    {
        Task<IdentityResult> RegisterAsync(ApplicationUser user, string password);
        Task<bool> LoginAsync(string email, string password);
        Task LogOutAsync();

        Task<UserDTO> GetByIdAsync(string id);
    }
}
