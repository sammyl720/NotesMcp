using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotesMcp.Data;
using NotesMcp.Services;
using NotesMcp.Tools;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<NotesTool>();

builder.Services.AddDbContext<NoteContext>();
builder.Services.AddSingleton<INoteService, NoteService>();

await builder.Build().RunAsync();