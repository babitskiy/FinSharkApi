namespace api.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareOne(this IApplicationBuilder builder)
            => builder.UseMiddleware<MiddlewareOne>();

        public static IApplicationBuilder UseMiddlewareTwo(this IApplicationBuilder builder)
            => builder.UseMiddleware<MiddlewareTwo>();

        public static IApplicationBuilder UseMiddlewareThree(this IApplicationBuilder builder)
            => builder.UseMiddleware<MiddlewareThree>();
    }
}