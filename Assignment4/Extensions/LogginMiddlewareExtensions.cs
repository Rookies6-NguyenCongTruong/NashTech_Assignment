using Assignment4.Middlewares;

namespace Assignment4.Extensions;
public static class LogginMiddlewareExtensions
{
    public static IApplicationBuilder UseLogginMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LogginMiddleware>();
    }
}