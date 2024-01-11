using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.Implementation;
using VanaKrizan.Utulek.Infrastructure.Database;
using VanaKrizan.Utulek.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// add Identity (úèty, role)
builder.Services.AddIdentity<User, Role>()
     .AddEntityFrameworkStores<UtulekDbContext>()
     .AddDefaultTokenProviders();
// config Identity (úèty, role)
builder.Services.Configure<IdentityOptions>(options =>
{
    #region Pravidla Hesla
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1;
    #endregion
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Security/Account/Login";
    options.LogoutPath = "/Security/Account/Logout";
    options.SlidingExpiration = true;
});

builder.Services.AddScoped<IAccountService, AccountIdentityService>();



// config Databáze
string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.34");

builder.Services.AddDbContext<UtulekDbContext>(
    optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));    
        // popø nahradit builder.Services.AddMySql<UtulekDbContext>(connectionString, serverVersion)

// migrace Databází



// propojení interface s implementací v Applications
builder.Services.AddScoped<IPetService, PetDBService>();
builder.Services.AddScoped<IHomeService, HomeService>();

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

app.UseAuthentication();
app.UseAuthorization();

// pøipojení Areas (upravené z ScaffoldingReadMe.txt)
app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
