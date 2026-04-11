namespace ConvertiX.Services;

public class CurrenciesService : ICurrenciesService
{
    private readonly HttpClient _httpClient;

    public CurrenciesService(HttpClient httpClient) => _httpClient = httpClient;
    
    public async Task<List<Currency>> GetCurrenciesAsync()
    {
        try
        {
            string response = await _httpClient.GetStringAsync("https://api.frankfurter.app/latest?from=USD");
            
            using var jsonDocument = JsonDocument.Parse(response);
            var rates = jsonDocument.RootElement.GetProperty("rates").GetRawText();
            var result = JsonSerializer.Deserialize<Dictionary<string, decimal>> (rates);
            
            if (result is not null)
            {
                foreach (var res in result)
                    Currencies.CurrenciesList.Add(new Currency(res.Key, res.Value));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"No response from Frankfurter API or other error: {ex.Message}");
            throw new Exception($"No response from Frankfurter API or other error: {ex.Message}");
        }

        return Currencies.CurrenciesList;
    }
}