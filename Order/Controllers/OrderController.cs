using Microsoft.AspNetCore.Mvc;
using OrderSolution.Models;
namespace OrderSolution.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
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
                // generate a random order number between 1 and 99999
                Random random = new Random();
                int randomOrderNumber = random.Next(1, 99999);
                //return Json(order.OrderNo);
                order.OrderNo = randomOrderNumber;
                return Json(new { OrderNumber = order.OrderNo});
            }
        }
    }
}
