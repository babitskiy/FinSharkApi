namespace api.Middlewares
{
    public class MiddlewareTwo
    {
        private readonly RequestDelegate _next;

        public MiddlewareTwo(RequestDelegate next)
            => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            System.Console.WriteLine("Two before");
            await _next.Invoke(context);
            System.Console.WriteLine("Two after");
        }
    }
}