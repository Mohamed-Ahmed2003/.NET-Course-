

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Run( async (HttpContext context) =>
{
    Boolean flag = false;
    int first = 0,second = 0, result=0;
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("firstNumber"))
        {
            string firstString = context.Request.Query["firstNumber"][0];
            if (!string.IsNullOrEmpty(firstString))
            {
                first = int.Parse(firstString);
            }
            else
            {
                flag = true;
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("<p>invalid input for: firstNumber\n<p>");
            }
        }
        else
        {
            flag = true;
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("<h1>invalid input for 'firstNumber'\n");
        }

        if (context.Request.Query.ContainsKey("secondNumber"))
        {
            string secondString = context.Request.Query["secondNumber"][0];
            if (!string.IsNullOrEmpty(secondString))
            {
                second = int.Parse(secondString);
            }
            else
            {
                flag = true;
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("invalid input for:secondNumber\n");

            }
        }
        else
        {
            flag = true;
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("invalid input for 'secondNumber'\n");
            
        }

        if (context.Request.Query.ContainsKey("operation"))
        {
            string operation = Convert.ToString(context.Request.Query["operation"][0]);
            switch (operation)
            {
                case "add":
                    result = first + second;
                    if(!flag)
                        await context.Response.WriteAsync($"the result is {result}");
                    break;
                case "subtract":
                    result = first - second;
                    if(!flag)
                        await context.Response.WriteAsync($"the result is {result}");
                    break;
                case "multiply":
                    result = first * second;
                    if(!flag)
                        await context.Response.WriteAsync($"the result is {result}");
                    break;
                case "division":
                    result = first / second;
                    if(!flag)
                        await context.Response.WriteAsync($"the result is {result}");
                    break;
                case "moduls":
                    result = first % second;
                    if(!flag)
                        await context.Response.WriteAsync($"the result is {result}");
                    break;
                default:
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("invalid input for operation\n");
                    break;

            }
        }
        else
        {
            if (context.Response.StatusCode==200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("invalid input for 'operation'\n");
        }
    }
});
app.Run();
