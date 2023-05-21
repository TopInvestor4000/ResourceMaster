using Mapster;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Repositories.CustomerRepository;
using ResourceMaster.DAL.Repositories.ProjectRepository;
using ResourceMaster.DAL.Repositories.ResourceProject;
using ResourceMaster.DAL.Repositories.ResourceRepository;
using ResourceMaster.DAL.Repositories.SkillRepository;
using ResourceMaster.DAL.TestData;
using ResourceMaster.Services.CustomerService;
using ResourceMaster.Services.MatchingService;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .ConfigureLogging((_, loggingBuilder) => loggingBuilder.ClearProviders())
    .UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();

builder.Services.AddTransient<DatabaseContext>();

TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
TypeAdapterConfig.GlobalSettings.Default
    .EnumMappingStrategy(EnumMappingStrategy.ByName);

//Add Repos
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IResourceProjectRepository, ResourceProjectRepository>();

//Add services
builder.Services.AddScoped<CustomerService, CustomerService>();
builder.Services.AddScoped<ProjectService, ProjectService>();
builder.Services.AddScoped<ResourceService, ResourceService>();
builder.Services.AddScoped<SkillService, SkillService>();
builder.Services.AddScoped<MatchingService, MatchingService>();
builder.Services.AddScoped<AvailabilityService, AvailabilityService>();

// Apply migrations
DatabaseContext? dbContext = builder?.Services?.BuildServiceProvider()?.GetService<DatabaseContext>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
dbContext?.Database.Migrate();

// Add seed data
var seedData = new SeedData(dbContext);
await seedData.AddSeedDataAsync();

var app = builder?.Build();

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
