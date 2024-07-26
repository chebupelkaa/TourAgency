
using Agency.Models;
using Agency.UserService;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public readonly IContractService _contractService;
        public ToursController(IMapper mapper, ITourService tourService, IReviewService reviewService,
            ICurrentUserService currentUserService, IUserService userService, IReservationService reservationService, IContractService contractService)
        {
            _mapper = mapper;
            _tourService = tourService;
            _reviewService = reviewService;
            _currentUserService = currentUserService;
            _userService = userService;
            _reservationService = reservationService;
            _contractService = contractService;
        }


        public async Task<ActionResult> Index()
        {
            var tours = _mapper.Map<List<ModelTour>>(await _tourService.GetAllAsync());

            return View(tours);
        }
        public async Task<ActionResult> AllGroups()
        {
            var tours = _mapper.Map<List<ModelTour>>(await _tourService.GetAllAsync());

            return View(tours);
        }
        public async Task<ActionResult> SearchTour(string departureCountry, string arrivalCountry, DateTime startDate, int numberOfNights)
        {
            var searchedTours = _mapper.Map<List<ModelTour>>(await _tourService.SearchToursAsync(departureCountry, arrivalCountry, startDate, numberOfNights));
            if (searchedTours != null)
            {
                ViewBag.SearchResults = searchedTours;
            }

            return View("Index", searchedTours);
        }
        public async Task<IActionResult> Details(ModelTour model)
        {
            var reviews = _mapper.Map<List<ModelReview>>(await _reviewService.FindReviewsForTour(model.Id));
            ViewBag.ReviewsForTour = reviews;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ModelReview model)
        {
            if (User.Identity.IsAuthenticated)
            {

                ReviewDTO review = new ReviewDTO();
                var userId = _currentUserService.UserId;

                review.Rating = model.Rating;
                review.ReviewText = model.ReviewText;
                review.ReviewDate = DateTime.Now;
                review.ApplicationUserId = userId;
                review.TourId = model.TourId;

                var tour = _mapper.Map<ModelTour>(await _tourService.GetByIdAsync(model.TourId));
                var result = _mapper.Map<ModelReview>(await _reviewService.CreateAsync(review));

                if (result != null)
                {
                    return Json(new { success = true, tour = tour });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            else return RedirectToAction("Guest");
            //return View(result);
        }


        //[HttpGet]
        public async Task<IActionResult> ReviewsForTour(ModelTour model)
        {
            var reviews = _mapper.Map<List<ModelReview>>(await _reviewService.FindReviewsForTour(model.Id));
            return View("Details", reviews);
        }


        [HttpPost]
        public async Task<IActionResult> AddReservation(ModelTour model)
        {
            if (User.Identity.IsAuthenticated)
            {
                ReservationDTO reservation = new ReservationDTO();

                var userId = _currentUserService.UserId;
                //var user = _mapper.Map<ApplicationUser>(await _userService.GetByIdAsync(userId));

                reservation.Status = "В ожидании подтверждения";
                reservation.TourId = model.Id;
                reservation.ApplicationUserId = userId;
                reservation.DateOfReservation = DateTime.Now;
                reservation.SumOfPayment = model.Price;


                TempData["SuccessMessage"] = "Тур Забронирован. Ждите подтверждения от менеджера.";
                var result = _mapper.Map<ModelReservation>(await _reservationService.CreateAsync(reservation));

                return View(result);
            }
            else return RedirectToAction("Guest");
        }






    }
}
