namespace apbd_lab12.Middlewares;

public class CustomExceptionHandler
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    // Implement exception handling here
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Code to execute before the next middleware
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            // Code to execute after the next middleware
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Exception: {ex.Message}");

            // Set the response status code and content
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected error occurred.");
        }
    }
}