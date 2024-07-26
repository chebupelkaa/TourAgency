using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    internal class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ITourRepository _tourRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewService(IMapper mapper, IReviewRepository reviewRepository, 
            ITourRepository tourRepository, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _tourRepository = tourRepository;
            _userManager = userManager;
        }
        public async Task<ReviewDTO> CreateAsync(ReviewDTO entity)
        {
            var mappedEntity = _mapper.Map<Review>(entity);
            mappedEntity.Tour = null;
            mappedEntity.ApplicationUser = await _userManager.FindByIdAsync(entity.ApplicationUserId);
            await _reviewRepository.CreateAsync(mappedEntity);

            return entity;
        }

        public Task<ReviewDTO> DeleteAsync(ReviewDTO entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<ReviewDTO>> GetAllAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            var mappedReviews=_mapper.Map<IEnumerable<ReviewDTO>>(reviews);
            return mappedReviews;
        }
        public async Task<IEnumerable<ReviewDTO>> FindReviewsForTour(int tourId)
        {
            var reviews = await _reviewRepository.GetAllAsync();
            var tours = await _tourRepository.GetAllAsync();
            var filteredReviews = reviews.Where(r => r.TourId == tourId);
            var mappedReviews = _mapper.Map<IEnumerable<ReviewDTO>>(filteredReviews);
            return mappedReviews;
        }
        public Task<ReviewDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDTO> UpdateAsync(ReviewDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
