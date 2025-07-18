using E_Commerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/order")]
        [HttpPost]
        public IActionResult Index(Order order)
        {
            if(!ModelState.IsValid)
            {
                string massage = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(massage);          
            }
            Random random = new Random();
            int result = random.Next(1, 9999);
            return Json(result);
        }
    }
}
