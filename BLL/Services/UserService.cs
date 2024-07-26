
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

using System.Security.Claims;

namespace BLL.Services
{
    internal class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(IMapper mapper, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterAsync(ApplicationUser user, string password)
        {
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User is null." });
            }

            if (await _roleManager.FindByNameAsync(AvailableRoles.Client) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(AvailableRoles.Client));
            }
            if (await _roleManager.FindByNameAsync(AvailableRoles.Manager) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(AvailableRoles.Manager));
            }

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return result;
            }

            var newUser = await _userManager.FindByIdAsync(user.Id);
            var roleClaim = new Claim(ClaimTypes.Role, "Client");
            await _userManager.AddClaimAsync(newUser, roleClaim);

            await _signInManager.SignInAsync(newUser, false);
            await _userManager.AddToRoleAsync(newUser, AvailableRoles.Client);
            return IdentityResult.Success;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, true, false);

            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserDTO> CreateAsync(UserDTO entity)
        {
            //var mappedEntity = _mapper.Map<User>(entity);
            //await _userRepository.CreateAsync(mappedEntity);
            //return entity;
            throw new NotImplementedException();
        }

        public Task<UserDTO> DeleteAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var entity = _mapper.Map<UserDTO>(user);
            return entity;
        }
        public async Task<UserDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<UserDTO> UpdateAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
