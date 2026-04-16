namespace ConvertiX;

public class ConvertViewModel
{
    [Required(ErrorMessage = "Введіть суму")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Оберіть валюту")]
    public CurrencyCode? From { get; set; }

    [Required(ErrorMessage = "Оберіть валюту")]
    public CurrencyCode? To { get; set; }

    public string? Result { get; set; }
}