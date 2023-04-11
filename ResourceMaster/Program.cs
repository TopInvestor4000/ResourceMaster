using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ResourceMaster.DAL.Repositories.MyTableRepository;
using ResourceMaster.Data;
using ResourceMaster.Services.MyTableService;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .ConfigureLogging((_, loggingBuilder) => loggingBuilder.ClearProviders())
    .UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();

builder.Services.AddSingleton<DatabaseContext>();

//Add Repos
builder.Services.AddScoped<IMyTableRepository, MyTableRepository>();

//Add services
builder.Services.AddScoped<MyTableService, MyTableService>();

// Apply migrations
var dbContext = builder.Services.BuildServiceProvider().GetService<DatabaseContext>();
dbContext.Database.Migrate();

var app = builder.Build();

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
