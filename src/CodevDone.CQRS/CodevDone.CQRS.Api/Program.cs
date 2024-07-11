using CodevDone.CQRS.Api.Extensions;



var builder = WebApplication.CreateBuilder(args);

// Setting Ports
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7002); // to listen for incoming http connection on port 5001
    options.ListenAnyIP(7004, configure => configure.UseHttps()); // to listen for incoming https connection on port 7001
});
// End Setting Port

builder.RegisterServices(typeof(Program));

var app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));


app.Run();


