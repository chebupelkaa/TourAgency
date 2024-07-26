using Agency.Models;
using Agency.UserService;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Controllers
{
    public class UsersController:Controller
    {
        private readonly IUserService _userService;
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UsersController(IUserService userService, IMapper mapper, ICurrentUserService currentUserService, IReservationService reservationService)
        {
            _userService = userService;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _reservationService = reservationService;
        }

    
        public async Task<ActionResult> InfoAboutUserAsync()
        {
            var userId = _currentUserService.UserId;
            var user = _mapper.Map<ModelUser>(await _userService.GetByIdAsync(userId));
            ViewBag.UserEntity = user;
            return View(user);
        }

        public async Task<ActionResult> ReservationsForUser()
        {
            var userId = _currentUserService.UserId;
            var res = _mapper.Map<List<ModelReservation>>(await _reservationService.FindReservationsByUserId(_currentUserService.UserId));
            ViewBag.ReservationsForUser = res;
            return View(res);

        }
    }
}
