namespace ConvertiX;

public class Currency : ICurrency
{
    private static int _idCounter = 0;
    
    public int Id { get; set; }
    public CurrencyCode Code { get; set; }
    public string Name { get; set; }
    public decimal Rate { get; set; }
    
    public Currency(string code, decimal rate)
    {
        Id = ++_idCounter;
        if (Enum.TryParse(code, out CurrencyCode codeEnum))
            Code = codeEnum;
        Name = Code.GetCurrencyName();
        Rate = rate;
    }
}