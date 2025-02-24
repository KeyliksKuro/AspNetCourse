namespace Lesson1.middleware
{
    public class TimeMiddleware
    {
        private readonly RequestDelegate next;

        public TimeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/time")
            {
                await context.Response.WriteAsync(DateTime.Now.ToLongTimeString());
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
    public static class TimeExtensions
    {
        public static IApplicationBuilder UseTime(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}
