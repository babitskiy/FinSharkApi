namespace api.Middlewares
{
    public class MiddlewareThree
    {
        private readonly RequestDelegate _next;

        public MiddlewareThree(RequestDelegate next)
            => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            System.Console.WriteLine("Three before");
            await _next.Invoke(context);
            System.Console.WriteLine("Three after");
        }
    }
}