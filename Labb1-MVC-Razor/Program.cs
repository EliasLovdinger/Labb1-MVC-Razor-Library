using Labb1_MVC_Razor.Models;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.
UseSqlServer(builder.Configuration.
GetConnectionString("DefConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<Cart>(c => Cart.GetCart(c));
builder.Services.AddScoped<IRentBookRepository, RentBookRepository>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddRazorPages();

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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
