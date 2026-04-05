namespace ConvertiX;

public interface ICurrency
{
    public int Id { get; set; }
    public CurrencyCode Code { get; set; }
    public string Name { get; }
    public decimal Rate { get; set; }
}