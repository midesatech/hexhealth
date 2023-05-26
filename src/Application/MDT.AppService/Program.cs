using MDT.AppService;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// CREATE STARTUP INSTANCE
var startup = new Startup(builder.Configuration);

// CONFIGURE SERVICES 
startup.ConfigureServices(builder.Services);
// Add services to the container.


var app = builder.Build();

/* CONFIGURE LIFETIME */
startup.Configure(app, app.Environment);

app.MapControllers();
app.Run();