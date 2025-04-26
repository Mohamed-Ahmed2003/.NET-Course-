using System.Runtime.InteropServices;

string[] countries =
{
    "United state",
    "canada ",
    "United Kingdom",
    "india",
    "japan"
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapGet("/countries", async context =>
    {
        for(int i = 0; i < countries.Length; i++)
        {
            await context.Response.WriteAsync($"{i+1}, {countries[i]}\n");
        }
    });
    endpoints.MapGet("/countries/{id:int}", async context =>
    {
        int parameter = Convert.ToInt32(context.Request.RouteValues["id"]);
        if (parameter > 5&& parameter<100)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("no country");
        }
        else if(parameter > 100)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("The CountryID should be between 1 and 100");
        }
        else if(parameter > 0)
        {
            await context.Response.WriteAsync(countries[parameter - 1]);
        }
    });
});

app.Run();
