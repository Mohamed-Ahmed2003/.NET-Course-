using Service_Contract;
using Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();  
/*builder.Services.AddTransient<IWeatherService, WeatherService>();*/
builder.Services.Add(new ServiceDescriptor(
    typeof(IWeatherService),
    typeof(WeatherService),
    ServiceLifetime.Transient)
);
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
