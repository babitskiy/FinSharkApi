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

        public static IApplicationBuilder UseCustomParameterMiddleware(this IApplicationBuilder builder, string parameter)
            => builder.UseMiddleware<MiddlewareCustomParameter>(parameter);

        public static IApplicationBuilder UseSandboxMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddlewareOne();
            builder.UseMiddlewareTwo();

            builder.Use(async(context, next) =>
            {
                System.Console.WriteLine("Custom Use before");
                await next.Invoke();
                System.Console.WriteLine("Custom Use after");
            });

            builder.UseWhen(
                context => true,
                appBuilder =>
                {
                    appBuilder.Use(async (context, next) =>
                    {
                        System.Console.WriteLine("Custom Use inside UseWhen before");
                        await next.Invoke();
                        System.Console.WriteLine("Custom Use inside UseWhen after");
                    });

                    appBuilder.Run(async context =>
                    {
                        await Task.Run(() => Console.WriteLine("Custom Run inside UseWhen after"));
                    });
            });

            builder.UseMiddlewareThree();
            builder.UseCustomParameterMiddleware("Four");
            builder.Run(async context =>
                    {
                        await Task.Run(() => Console.WriteLine("Hello World!"));
                    });
            builder.UseCustomParameterMiddleware("Five");
            builder.UseCustomParameterMiddleware("Six");

            return builder;
        }
    }
}