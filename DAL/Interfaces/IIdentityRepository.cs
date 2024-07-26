using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IIdentityRepository
    {
        Task<string?> GetUsersNameAsync(string UserId);
        Task<bool> IsInRoleAsync(string UserId,string role);
        Task<bool>AuthorizeAsync(string UserId, string policyName);
        Task<string> CreateUsersAsync(string username, string password);
        Task<string> DeleteUsersAsync(string usersId);
    }
}
