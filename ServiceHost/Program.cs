using AccountManagement.Configuration;
using BlogManagement.Configuration;
using CommentManagement.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using MyFramework.Tools;
using MyFramework.Tools.Authentication;
using ServiceHost;
using ShopManagement.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

ShopBootStrapper Shop = new();
DiscountBootstrapper Discount = new();
InventoryBootStrapper Inventory = new();
BlogBootStrapper Blog = new();
CommentBootStrapper Comment = new();
AccountBootstrapper Account = new();

var ConnString = builder.Configuration.GetSection("ConnString")["OnlineShopDb"];

Shop.ConfigService(builder.Services, ConnString);
Discount.ConfigService(builder.Services, ConnString);
Inventory.ConfigService(builder.Services, ConnString);
Blog.ConfigService(builder.Services, ConnString);
Comment.ConfigService(builder.Services, ConnString);
Account.ConfigService(builder.Services, ConnString);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<IZarinPalFactory, ZarinPalFactory>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Account");
        o.LogoutPath = new PathString("/Account");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea",
        builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ContentUploader }));

    options.AddPolicy("Shop",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));

    options.AddPolicy("Discount",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));

    options.AddPolicy("Account",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));
});

builder.Services.AddRazorPages()
    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
               .AddRazorPagesOptions(options =>
               {
                   options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
                   options.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
                   options.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
                   options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
               });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
