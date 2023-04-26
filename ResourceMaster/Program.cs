using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Repositories.CustomerRepository;
using ResourceMaster.DAL.Repositories.ProjectRepository;
using ResourceMaster.DAL.Repositories.ResourceRepository;
using ResourceMaster.DAL.Repositories.SkillRepository;
using ResourceMaster.Services.CustomerService;
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
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

//Add services
builder.Services.AddScoped<CustomerService, CustomerService>();
builder.Services.AddScoped<ProjectService, ProjectService>();
builder.Services.AddScoped<ResourceService, ResourceService>();
builder.Services.AddScoped<SkillService, SkillService>();

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
