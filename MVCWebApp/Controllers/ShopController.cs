using Microsoft.AspNetCore.Mvc;

namespace MVCWebApp.Controllers
{
    [Route("shop")]
    public class ShopController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult BuyById([FromRoute] int id)
        {
            return View();
        }
    }
}
