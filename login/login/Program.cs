using login.middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.useHandler();
app.Run();


