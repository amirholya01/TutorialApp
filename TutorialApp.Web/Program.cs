using Microsoft.EntityFrameworkCore;
using TutorialApp.Core.Services;
using TutorialApp.Core.Services.Interfaces;
using TutorialApp.Datalayer.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySqlServerConnection");
builder.Services.AddDbContext<TutorialAppContext>(options => {
    options.UseSqlServer(connectionString);
});
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
