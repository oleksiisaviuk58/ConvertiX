namespace ConvertiX.Controllers;

public class ConverterController : Controller
{
    [HttpGet("/")]
    public async Task<ViewResult> Index()
    {
        try { await CurrencyAPIService.GetRatesAsync(); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        
        ViewBag.Currencies = new SelectList(Currencies._currencies, "Id", "Name");
        ViewBag.CryptoCurrencies = new SelectList(Currencies._currencies, "Id", "Name");
        
        return View();
    }

    [HttpPost("/")]
    public async Task<ViewResult> Index(string amount, int from, int to)
    {
        try { await CurrencyAPIService.GetRatesAsync(); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

        var fromCurrency = Currencies._currencies[from];
        var toCurrency = Currencies._currencies[to];
        
        try
        {
            if (!string.IsNullOrEmpty(amount))
            {
                if (decimal.TryParse(amount, out decimal amountResult))
                    ViewBag.Result = amountResult * fromCurrency.Rate / toCurrency.Rate;
            }
        }
        catch (DivideByZeroException ex) { Console.WriteLine(ex.Message); }
        
        ViewBag.Currencies = new SelectList(Currencies._currencies, "Id", "Name");
        ViewBag.CryptoCurrencies = new SelectList(Currencies._currencies, "Id", "Name");
        
        return View();
    }
}