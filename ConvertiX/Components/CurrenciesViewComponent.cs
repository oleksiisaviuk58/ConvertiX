namespace ConvertiX;

public class CurrenciesViewComponent : ViewComponent
{
    private readonly ICurrenciesService _currenciesService;

    public CurrenciesViewComponent(ICurrenciesService currenciesService) => _currenciesService = currenciesService;
    
    public async Task<IViewComponentResult> InvokeAsync(string name, string? selectedValue)
    {
        var currencies = await _currenciesService.GetCurrenciesAsync();
        
        ViewBag.Name = name;
        ViewBag.SelectedValue = selectedValue;
        var selectList = new SelectList(currencies, "Code", "Name", selectedValue);

        return View("Currencies", selectList);
    }
}