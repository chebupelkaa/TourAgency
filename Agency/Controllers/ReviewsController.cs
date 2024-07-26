using Agency.Models;
using Agency.UserService;
using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public ReviewsController(IMapper mapper, IReviewService reviewService, IUserService userService, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _reviewService = reviewService;
            _currentUserService = currentUserService;
            _userService = userService;
        }
        public async Task<IActionResult> AllReviews()
        {
            var entity = await _reviewService.GetAllAsync();
            var reviews = _mapper.Map<List<ModelReview>>(entity);

            return View(reviews);
        }
        public async Task<IActionResult> ReviewForTour()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ModelReview model)
        {
            if (!ModelState.IsValid)
            {
               return View(model);
            }
            ModelReview review = _mapper.Map<ModelReview>(model);
            model.ReviewText = review.ReviewText;
            //return View();
            return RedirectToAction("AllReviews");
        }


    }
}
