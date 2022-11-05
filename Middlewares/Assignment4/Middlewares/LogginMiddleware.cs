using System.Text.Json;

namespace Assignment4.Middlewares;
public class LogginMiddleware
{
    private readonly RequestDelegate _next;

    public LogginMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stream = new StreamReader(context.Request.Body);
        var dataContext = context.Request;
        var body = await stream.ReadToEndAsync();

        var requestData = new
        {
            Schema = dataContext.Scheme,
            Host = dataContext.Host.ToString(),
            Path = dataContext.Path.ToString(),
            QueryString = dataContext.QueryString.ToString(),
            RequestBody = body
        };

        // Use StreamWriter to write data to file, it will also automatically create one if the file doesnt exist already
        using (StreamWriter writer = File.AppendText("file.txt"))
        {
            // Convert requestdata to JSON string
            var data = JsonSerializer.Serialize(requestData);

            await writer.WriteLineAsync("================================================================");
            await writer.WriteLineAsync(data);
        }

        // Call the next delegate/middleware in the pipeline
        await _next(context);
    }
}