using hotelAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace hotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : Controller
    {
        private readonly AppDbContext context;

        public TourController(AppDbContext context)
        {
            this.context = context;
            
        }

        [HttpGet]
        public IActionResult GetAllTours()
        {
            var AllTours = context.Tours.ToList();
            return Ok(AllTours);
        }
    }
}
