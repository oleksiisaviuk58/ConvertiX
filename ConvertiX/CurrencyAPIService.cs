namespace ConvertiX;

public static class CurrencyAPIService
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public static async Task GetRatesAsync()
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
                    Currencies._currencies.Add(new Currency(res.Key, res.Value));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"No response from Frankfurter API or other error: {ex.Message}");
            throw new Exception($"No response from Frankfurter API or other error: {ex.Message}");
        }
    }
}