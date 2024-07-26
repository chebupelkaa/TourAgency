using Agency.Models;
using AutoMapper;
using BLL.DTO;
using BLL.EmailEntity;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Agency.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IContractService _contractService;
        private readonly ITourService _tourService;
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;
        private readonly IEmailService _mailService;
        private readonly IMapper _mapper;
        public ReservationsController(IMapper mapper, ITourService tourService, IReservationService reservationService,
            IUserService userService, IContractService contractService, IEmailService mailService,IGroupService groupService)
        {
            _mapper = mapper;
            _reservationService = reservationService;
            _tourService = tourService;
            _contractService = contractService;
            _userService = userService;
            _mailService = mailService;
            _groupService = groupService;
        }

        public async Task<ActionResult> AllReservations()
        {
            var reservations = _mapper.Map<List<ModelReservation>>(await _reservationService.GetAllAsync());
            return View(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> AddContract(int reservationId)
        {
            ContractDTO contract = new ContractDTO();
            contract.DateOfSubscribe = DateTime.Now;
            contract.ReservationId = reservationId;

            var tour = await _tourService.GetTourByReservationId(reservationId);
            var res = await _reservationService.GetByIdAsync(reservationId);
            TempData["ContractSuccessMessage"] = "Договор оформлен.Письмо отправлено на e-mail";
            var result = _mapper.Map<ModelContract>(await _contractService.CreateAsync(contract));

            if (result!=null)
            {
                await _groupService.AddToGroup(tour.Id, res.ApplicationUserId);
            }

            await UpdateReservationToYes(reservationId);
            await SendEmail(res.ApplicationUser.Email,tour);
            return View();
        }
        public async Task<IActionResult> UpdateReservationToYes(int reservationId)
        {
            var reservation = await _reservationService.GetByIdAsync(reservationId);
            reservation.Status = "Подтверждено";
            await _reservationService.UpdateAsync(reservation);
            return View();
        }
        public async Task<IActionResult> UpdateReservationToNo(int reservationId)
        {
            var reservation = await _reservationService.GetByIdAsync(reservationId);
            reservation.Status = "Отказано";
            await _reservationService.UpdateAsync(reservation);
            return RedirectToAction("AllReservations");
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string email,TourDTO tour)
        {
            try
            {
                await _mailService.SendEmailAsync(new EmailMessage() { 
                    Subject = "Договор на тур",
                    Text="Вы оформили тур "+tour.DepartureCountry+"-"+tour.ArrivalCountry,
                    To=email
                });
                ViewBag.Message = "Письмо успешно отправлено на почту клиента.";
            }
            catch (Exception ex)
            {
               
                ViewBag.Message = $"Ошибка при отправке письма: {ex.Message}";
            }

            return View();
        }

    }
}
