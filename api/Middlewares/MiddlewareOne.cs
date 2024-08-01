namespace api.Middlewares
{
    public class MiddlewareOne
    {
        private readonly RequestDelegate _next;

        public MiddlewareOne(RequestDelegate next)
            => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            System.Console.WriteLine("One before");
            await _next.Invoke(context);
            System.Console.WriteLine("One after");
        }
    }
}