using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : Controller
    {

        private readonly ITourService _tourService;
        private readonly IMapper _mapper;

        public TourController(ITourService tourService, IMapper mapper)
        {
           _tourService = tourService;
            _mapper = mapper;
          
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var tours = await _tourService.GetAllAsync();
            return Ok(tours);

            
        }
        /*        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourDTO>>> GetAllTours()
        {
            var tours = await _tourService.GetAllAsync();
            var tourDTOs = _mapper.Map<IEnumerable<TourDTO>>(tours);
            return Ok(tourDTOs);
        }
*/

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<TourDTO>>> SearchCheapTours(DateTime startDate, int numberOfNights)
        {
            var tours = await _tourService.GetAllAsync();
            var endDate = startDate.AddDays(numberOfNights);

            var cheapestTour = tours
                .Where(t => t.StartDate >= startDate && t.StartDate <= endDate) 
                .OrderBy(t => t.Price) 
                .FirstOrDefault(); 

            if (cheapestTour == null)
            {
                return NotFound(); 
            }
            return Ok(cheapestTour);
        }

        [HttpPost]
        public async Task<ActionResult<TourDTO>> Create([FromBody] TourDTO tour)
        {
            var res = await _tourService.CreateAsync(tour);
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TourDTO>> GetById(int id)
        {
            var tour = await _tourService.GetByIdAsync(id);
            if (tour == null)
            {
                return NotFound(); 
            }
            return Ok(tour);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] TourDTO tour)
        {
            var res = await _tourService.UpdateAsync(tour);
            return Ok(res); 
        }


    }
}
