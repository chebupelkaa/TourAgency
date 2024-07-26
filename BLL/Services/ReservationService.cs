using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    internal class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITourRepository _tourRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public ReservationService(IMapper mapper, IReservationRepository reservationRepository, 
            ITourRepository tourRepository, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _tourRepository = tourRepository;
            _userManager = userManager;
        }
        public async Task<ReservationDTO> CreateAsync(ReservationDTO entity)
        {
            var mappedEntity = _mapper.Map<Reservation>(entity);
            mappedEntity.Tour = null;
            mappedEntity.ApplicationUser = await _userManager.FindByIdAsync(entity.ApplicationUserId);
            await _reservationRepository.CreateAsync(mappedEntity);
            return entity;
        }
        public async Task<IEnumerable<ReservationDTO>> FindReservationsByUserId(string userId)
        {
            var allReservations= await _reservationRepository.GetAllAsync();
            //var user = await _userManager.FindByIdAsync(userId);
            var searchedReservations = allReservations.Where(t => t.ApplicationUser.Id == userId).ToList();

            var res = _mapper.Map<IEnumerable<ReservationDTO>>(searchedReservations);
            return res;
        }

        public Task<ReservationDTO> DeleteAsync(ReservationDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReservationDTO>> GetAllAsync()
        {
            var reservations = _mapper.Map<IEnumerable<ReservationDTO>>(await _reservationRepository.GetAllAsync());
            return reservations;
        }

        public async Task<ReservationDTO> GetByIdAsync(int id)
        {
            var reservation = _mapper.Map<ReservationDTO>( await _reservationRepository.GetByIdAsync(id));
            if (reservation == null)
            {
                throw new ArgumentException("User not found");
            }
            var entity = _mapper.Map<ReservationDTO>(reservation);
            return entity;
        }

        public async Task<ReservationDTO> UpdateAsync(ReservationDTO entity)
        {
            var mappedEntity = _mapper.Map<Reservation>(entity);
            mappedEntity.Tour = null;
            mappedEntity.Contracts = null;
            mappedEntity.ApplicationUser = null;
            await _reservationRepository.UpdateAsync(mappedEntity);
            return entity;
        }
    }
}
