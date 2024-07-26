using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Repositories
{
    public class IdentityRepository: IIdentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityRepository(UserManager<ApplicationUser> userManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService) 
        {
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        //public override async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        //{
        //    return await _dbSet.AsNoTracking().Include(u => u.GroupMembers).Include(u => u.Reviews).Include(u => u.Reservations).ToListAsync();//сделашеь для каждого репозитория
        //}
        //public async override Task<ApplicationUser> GetByIdAsync(int id) => await _dbSet.AsNoTracking().Include(u => u.GroupMembers).Include(u => u.Reviews).Include(u => u.Reservations).FirstOrDefaultAsync(a => a.Id == id);


        public async Task<bool> AuthorizeAsync(string UserId, string policyName)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return false;
            }
            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);
            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }
            
        public async Task<string> CreateUsersAsync(string username, string password)
        {
            var user = new ApplicationUser { UserName = username };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
                return user.Id;
            
            throw new Exception("Failed to create user");
        }

        public async Task<string> DeleteUsersAsync(string usersId)
        {
            var user = await _userManager.FindByIdAsync(usersId);
            if (user == null) throw new Exception("User not found");     
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded) return user.Id;

            throw new Exception("Failed to delete user");
        }

        public async Task<string?> GetUsersNameAsync(string UserId)
        {
            var user = await _userManager.Users.FirstAsync(u=>u.Id== UserId);
            return user.UserName;
        }

        public async Task<bool> IsInRoleAsync(string UserId, string role)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            return await _userManager.IsInRoleAsync(user, role);
        }
    }
}
