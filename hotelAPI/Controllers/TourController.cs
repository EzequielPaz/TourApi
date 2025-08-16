using hotelAPI.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase 
    {
        private readonly ITourService _service;

        public TourController(ITourService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTours()
        {
            var allTours = await _service.GetAllToursAsync();
            return Ok(allTours);
        }
    }
}
