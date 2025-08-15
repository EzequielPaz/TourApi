using Microsoft.AspNetCore.Mvc;

namespace hotelAPI.Controllers
{
    [ApiController]
    public class TourController : Controller
    {
        public TourController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
