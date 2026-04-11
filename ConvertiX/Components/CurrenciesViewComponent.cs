using ConvertiX.Services;

namespace ConvertiX;

public class CurrenciesViewComponent : ViewComponent
{
    private readonly ICurrenciesService _currenciesService;

    public CurrenciesViewComponent(ICurrenciesService currenciesService) => _currenciesService = currenciesService;
    
    public async Task<IViewComponentResult> InvokeAsync(string name)
    {
        var currencies = await _currenciesService.GetCurrenciesAsync();
        
        ViewBag.Name = name;
        var selectList = new SelectList(currencies, "Id", "Name");

        return View("Currencies", selectList);
    }
}