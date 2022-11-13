using WEB_053502_KHARLAP.Middleware;

namespace WEB_053502_KHARLAP.Data
{
    public static class AppExtension
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app) => app.UseMiddleware<LogMiddleware>();
    }
}
