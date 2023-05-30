using MDT.AppService;
using Microsoft.AspNetCore.Builder;
using System;

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
Console.Out.WriteLine("Application started. Press Ctrl+C to shut down.");
app.Run();


public partial class Program { }