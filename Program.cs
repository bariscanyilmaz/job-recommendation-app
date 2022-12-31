using Microsoft.EntityFrameworkCore;
using JobRecommendationApp.Models;
using JobRecommendationApp.Repositories;
using JobRecommendationApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(opt=>{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddTransient<QuestionRepository>();
builder.Services.AddTransient<EntryRepository>();
builder.Services.AddTransient<JobRepository>();

builder.Services.AddTransient<QuestionService>();
builder.Services.AddTransient<EntryService>();
builder.Services.AddTransient<JobService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
