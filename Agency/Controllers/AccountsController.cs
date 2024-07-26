using Agency.Models;
using Agency.UserService;
using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;

using Microsoft.AspNetCore.Mvc;

namespace Agency.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public AccountsController(IUserService userService, ICurrentUserService currentUserService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
            _currentUserService = currentUserService;
        }

        public IActionResult Guest()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(ModelUserForSignUp model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ApplicationUser user = _mapper.Map<ApplicationUser>(model);

            user.UserName = model.Email;
            user.Email = model.Email;
            user.Surname = model.Surname;
            user.Phone = model.Phone;

            var result = await _userService.RegisterAsync(user, model.Password);

            if (result.Succeeded)
            {
                //return RedirectToAction("Client", "Accounts");
                return RedirectToAction("InfoAboutUser", "Users");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> LogIn(ModelUserForSignIn model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //ModelState.Clear();

            var result = await _userService.LoginAsync(model.Email,model.Password);
       
            if (result)
            {
                ModelState.Clear();
                return RedirectToAction("InfoAboutUser", "Users");
            }
            else
            {
                ModelState.AddModelError("Password", "Неправильный пароль");
                return View(model);
            }    
        }
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOutAsync();
            return RedirectToAction("Guest", "Accounts");
        }

        public async Task<IActionResult> Client()
        {
            var userId = _currentUserService.UserId;
            var user = _mapper.Map<ModelUser>(await _userService.GetByIdAsync(userId));       
            //var user = _userService.GetByIdAsync(userId);

            if(user == null)return RedirectToAction("Guest", "Accounts");  
            else return View(user);
        }
    }
}
