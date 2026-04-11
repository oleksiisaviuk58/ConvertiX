using ConvertiX.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ICurrenciesService, CurrenciesService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();