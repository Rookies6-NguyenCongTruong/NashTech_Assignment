using Assignment4.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Im keeping this to get the path value as "/favicon.ico"
app.MapGet("/", () => "Hello World!");

// Custom middleware
app.UseLogginMiddleware();

app.Run();
