// Home controller change 1
using API_DesignPattern.Models.ErrorViewModel;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API_DesignPattern.Controllers
{
   // [ApiController]
   // [Route("api/[controller]")]
    public class HomeController : Controller
    {
       // [HttpGet("Error")]

        
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var model = new ErrorViewModel
            {
                Message = exceptionFeature?.Error.Message,
                Path = exceptionFeature?.Path,
                TraceId = HttpContext.TraceIdentifier
            };
            
            return View(model);  // Ok("Page Error");
        }
    }
}
    
