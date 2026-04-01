using Microsoft.AspNetCore.Mvc;

namespace ConvertiX.Controllers;

public class ConverterController : Controller
{
    [HttpGet("/")]
    public ViewResult Index() => View();
    
    [HttpPost("/convert")]
    public IActionResult Convert() => Ok("CONVERT!");
}