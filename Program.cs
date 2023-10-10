using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StephenBookShelf.Data;
using StephenBookShelf.DATADB;
using StephenBookShelf.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookStoreDBContextClass>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//I'm Going to include this portion of code inorder for the Details Action method to receive input BookId which has been manually set in advance.
app.MapControllerRoute(
    name: "bookDetails",
    pattern: "Bookstore/Details/{BookId}",
    defaults: new { controller = "Bookstore", action = "Details" }
);

app.MapRazorPages();




app.Run();
