namespace api.Middlewares
{
    public class MiddlewareCustomParameter
    {
        private readonly RequestDelegate _next;
        private readonly string _parameter;

        public MiddlewareCustomParameter(RequestDelegate next, string parameter)
        {
            _next = next;
            _parameter = parameter;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            System.Console.WriteLine(_parameter + " before");
            await _next.Invoke(context);
            System.Console.WriteLine(_parameter + " after");
        }
    }
}