namespace ConvertiX.Controllers;

public class ConverterController : Controller
{
    [HttpGet("/")]
    public ViewResult Index() => View();

    [HttpPost("/")]
    public ViewResult Index(ConvertViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (model.Amount <= 0)
            ModelState.AddModelError(nameof(model.Amount), "Некоретне значення");
        
        try
        {
            var from = Currencies.CurrenciesList.FirstOrDefault(x => x.Code == model.From);
            var to = Currencies.CurrenciesList.FirstOrDefault(x => x.Code == model.To);
            
            if (from is not null && to is not null)
            {
                ModelState.Remove(nameof(model.Result));
                
                var result = model.Amount * from.Rate / to.Rate; 
                model.Result = $"{result.ToString("F2", new CultureInfo("uk-UA"))} {to.Code}";
            }
        }
        catch (DivideByZeroException ex) { Console.WriteLine(ex.Message); }
        
        return View(model);
    }
}