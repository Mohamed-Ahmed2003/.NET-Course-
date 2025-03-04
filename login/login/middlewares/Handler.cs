using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;

namespace login.middlewares
{
    public class Handler
    {
        private readonly RequestDelegate _next;
        public Handler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Path == "/" && context.Request.Method == "POST")
            {
                StreamReader reader = new StreamReader(context.Request.Body);
                string body = reader.ReadToEndAsync().Result;
                Dictionary<string, StringValues> data = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
                string? email = null, password = null;

                if (data.ContainsKey("email"))
                {
                    email = Convert.ToString(data["email"][0]);

                }
                else
                {
                    if (context.Response.StatusCode == 200)
                        context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("invalid email\n");
                }
                if (data.ContainsKey("password"))
                {
                    password = Convert.ToString(data["password"][0]);
                }
                else
                {
                    if (context.Response.StatusCode == 200)
                        context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("invalid password \n");
                }
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    if (email == "admin@example.com" && password == "admin1234")
                        await context.Response.WriteAsync("Successful login\n");
                    else
                        await context.Response.WriteAsync("Invalid login");
                }


            }
            else
                await context.Response.WriteAsync("no Response \n");
        }
    }

    public static class HandlerExtention
    {
        public static IApplicationBuilder useHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Handler>();
        }
    }
}


