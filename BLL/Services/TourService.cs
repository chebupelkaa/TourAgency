using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;


namespace BLL.Services
{
    internal class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public TourService(IMapper mapper, ITourRepository tourRepository, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _tourRepository = tourRepository;
            _reservationRepository = reservationRepository;
        }
        public async Task<TourDTO> CreateAsync(TourDTO entity)
        {
            var mappedEntity = _mapper.Map<Tour>(entity);
            await _tourRepository.CreateAsync(mappedEntity);
            return entity;
        }

        public Task<TourDTO> DeleteAsync(TourDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TourDTO>> GetAllAsync() =>
            _mapper.Map<IEnumerable<TourDTO>>(await _tourRepository.GetAllAsync());



        public async Task<IEnumerable<TourDTO>> SearchToursAsync(string departureCountry, string arrivalCountry, DateTime startDate, int numberOfNights)
        {
            var allTours=await _tourRepository.GetAllAsync();
            var searchedTours=allTours.Where(t => t.DepartureCountry == departureCountry 
                && t.ArrivalCountry == arrivalCountry 
                && t.StartDate.Date == startDate.Date
                && t.NumberOfNights == numberOfNights).ToList();
            var tourDtos = _mapper.Map<IEnumerable<TourDTO>>(searchedTours);
            return tourDtos;
        }
        public async Task<IEnumerable<TourDTO>> SearchTours(DateTime startDate, string arrivalCountry)
        {
            var allTours = await _tourRepository.GetAllAsync();
            var searchedTours = allTours.Where(t =>  t.ArrivalCountry == arrivalCountry
                  && t.StartDate.Date == startDate.Date).ToList();
            var tourDtos = _mapper.Map<IEnumerable<TourDTO>>(searchedTours);
            return tourDtos;
        }
        public async Task<TourDTO> GetTourByReservationId(int reservationsId)
        {
            var res= await _reservationRepository.GetByIdAsync(reservationsId);
            var entitiy= _mapper.Map<TourDTO>(res.Tour);
            return entitiy;
        }

        public async Task<TourDTO> GetByIdAsync(int id)
        {
            var tour = _mapper.Map<TourDTO>(await _tourRepository.GetByIdAsync(id));
            return tour;
        }

        public async Task<TourDTO> UpdateAsync(TourDTO entity)
        {
            var existingTour = await _tourRepository.GetByIdAsync(entity.Id);

            if (existingTour == null)
            {
                throw new ArgumentException("Tour not found"); 
            }

            existingTour.Description = entity.Description;
            existingTour.StartDate = entity.StartDate;
            existingTour.Price = entity.Price;
            existingTour.NumberOfNights = entity.NumberOfNights;
            existingTour.Pictures = entity.Pictures;
            existingTour.ArrivalCountry = entity.ArrivalCountry;
            existingTour.DepartureCountry = entity.DepartureCountry;

            await _tourRepository.UpdateAsync(existingTour); 
            return entity;
        }
    }
}
