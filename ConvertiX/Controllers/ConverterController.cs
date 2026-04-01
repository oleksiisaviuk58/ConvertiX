using Microsoft.AspNetCore.Mvc;

namespace ConvertiX.Controllers;

public class ConverterController : Controller
{
    [HttpGet("/")]
    public ViewResult Index() => View();

    [HttpPost("/")]
    public ViewResult Index(string amount, string from, string to)
    {
        if (!string.IsNullOrEmpty(amount))
        {
            if (decimal.TryParse(amount, out decimal result))
                ViewBag.Result = result * 2;
        }
        
        return View();
    }
}