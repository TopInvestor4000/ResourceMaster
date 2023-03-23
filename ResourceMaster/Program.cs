using Microsoft.EntityFrameworkCore;
using ResourceMaster.DAL.Repositories.MyTableRepository;
using ResourceMaster.Data;
using ResourceMaster.Services.MyTableService;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Grafana.Loki;

var builder = WebApplication.CreateBuilder(args);


var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log.log", rollingInterval: RollingInterval.Day)
    .WriteTo.GrafanaLoki("http://logging-svc:3100")
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



builder.Services.AddSingleton<DatabaseContext>();

//Add Repos
builder.Services.AddScoped<IMyTableRepository, MyTableRepository>();

//Add services
builder.Services.AddScoped<MyTableService, MyTableService>();

var app = builder.Build();

// Apply migrations
var dbContext = builder.Services.BuildServiceProvider().GetService<DatabaseContext>();
dbContext.Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
