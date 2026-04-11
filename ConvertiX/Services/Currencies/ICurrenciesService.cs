namespace ConvertiX.Services;

public interface ICurrenciesService
{
    public Task<List<Currency>> GetCurrenciesAsync();
}