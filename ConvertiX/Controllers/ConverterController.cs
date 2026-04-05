using System.Globalization;

namespace ConvertiX.Controllers;

public class ConverterController : Controller
{
    [HttpGet("/")]
    public async Task<ViewResult> Index()
    {
        try { await CurrencyAPIService.GetRatesAsync(); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        
        ViewBag.Currencies = new SelectList(Currencies._currencies, "Id", "Name");
        return View();
    }

    [HttpPost("/")]
    public async Task<ViewResult> Index(decimal amount, int fromId, int toId)
    {
        try
        {
            var from = Currencies._currencies.FirstOrDefault(x => x.Id == fromId);
            var to = Currencies._currencies.FirstOrDefault(x => x.Id == toId);

            if (from is not null && to is not null)
            {
                var result = amount * from.Rate / to.Rate;
                ViewBag.Result = $"{result.ToString("F2", new CultureInfo("uk-UA"))} {to.Code}";
            }
        }
        catch (DivideByZeroException ex) { Console.WriteLine(ex.Message); }
        
        ViewBag.Currencies = new SelectList(Currencies._currencies, "Id", "Name");
        return View();
    }
}