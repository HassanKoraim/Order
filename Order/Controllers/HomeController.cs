using Microsoft.AspNetCore.Mvc;
using Ordersolution.Models;
namespace Ordersolution.Controllers
{
    public class HomeController : Controller
    {
        [Route("/order")]
        public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                string ErrorMessage = string.Join("\n", ModelState.Values
                                       .SelectMany(x => x.Errors)
                                                          .Select(x => x.ErrorMessage));
                return BadRequest(ErrorMessage);
            }
            else
            {
                return Json(order);
            }
        }
    }
}
