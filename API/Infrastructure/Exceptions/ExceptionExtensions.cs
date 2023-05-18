using API.Infrastructure.Exceptions.Middlewares;

namespace API.Infrastructure.Exceptions;

public static class ExceptionExtensions
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}