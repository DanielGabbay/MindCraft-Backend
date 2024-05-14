namespace MindCraft.Data.Authorization;

public class SwaggerAuthorizationMiddleware
{
    // Middleware to authorize Swagger UI access
    // This middleware is only used in development environment
    // In production, Swagger UI is disabled
    public SwaggerAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.User.Identity != null && context.Request.Path.StartsWithSegments("/swagger") && !context.User.Identity.IsAuthenticated)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await _next(context);
    }

    private readonly RequestDelegate _next;
}