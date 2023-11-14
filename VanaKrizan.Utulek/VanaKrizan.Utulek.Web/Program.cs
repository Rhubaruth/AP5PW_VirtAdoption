using Microsoft.EntityFrameworkCore;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.Implementation;
using VanaKrizan.Utulek.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// config Databáze
string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.34");

builder.Services.AddDbContext<UtulekDbContext>(
    optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));    
        // popø nahradit builder.Services.AddMySql<UtulekDbContext>(connectionString, serverVersion)

// migrace Databází



// propojení interface s implementací v Applications
builder.Services.AddScoped<IPetService, PetDFService>();
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
