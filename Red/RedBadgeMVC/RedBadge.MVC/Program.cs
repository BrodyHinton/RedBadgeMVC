using RedBadge.Data.Context;
using RedBadge.Services.Configurations;
using Microsoft.EntityFrameworkCore;
using RedBadge.Services.LeagueServices;
using RedBadge.Services.TeamServices;
using RedBadge.Services.PlayerServices;
using RedBadge.Services.GameServices;
using RedBadge.Services.HomeTeamServices;
using RedBadge.Services.AwayTeamServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(opt=>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MapperConfigurations));
builder.Services.AddScoped<ILeagueService,LeagueService>();
builder.Services.AddScoped<ITeamService,TeamService>();
builder.Services.AddScoped<IPlayerService,PlayerService>();
builder.Services.AddScoped<IGameService,GameService>();
builder.Services.AddScoped<IHomeTeamService,HomeTeamService>();
builder.Services.AddScoped<IAwayTeamService,AwayTeamService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
