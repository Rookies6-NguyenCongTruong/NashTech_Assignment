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
        var body = await stream.ReadToEndAsync();

        var requestData = new
        {
            Schema = context.Request.Scheme,
            Host = context.Request.Host.ToString(),
            Path = context.Request.Path.ToString(),
            QueryString = context.Request.QueryString.ToString(),
            RequestBody = body
        };

        using (StreamWriter writer = File.AppendText("file.txt"))
        {
            var data = JsonSerializer.Serialize(requestData);

            await writer.WriteLineAsync("================================================================");
            await writer.WriteLineAsync(data);
        }

        // Call the next delegate/middleware in the pipeline
        await _next(context);
    }
}