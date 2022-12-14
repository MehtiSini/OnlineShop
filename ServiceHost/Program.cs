using _0_Framework.Application;
using AccountManagement.Configuration;
using BlogManagement.Configuration;
using CommentManagement.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using MyFramework.Tools;
using ServiceHost;
using ShopManagement.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

ShopBootStrapper Shop = new ShopBootStrapper();
DiscountBootstrapper Discount = new DiscountBootstrapper();
InventoryBootStrapper Inventory = new InventoryBootStrapper();
BlogBootStrapper Blog = new BlogBootStrapper();
CommentBootStrapper Comment = new CommentBootStrapper();
AccountBootstrapper Account = new AccountBootstrapper();

var ConnString = builder.Configuration.GetSection("ConnString")["OnlineShopDb"];

Shop.ConfigService(builder.Services, ConnString);
Discount.ConfigService(builder.Services, ConnString);
Inventory.ConfigService(builder.Services, ConnString);
Blog.ConfigService(builder.Services, ConnString);
Comment.ConfigService(builder.Services, ConnString);
Account.ConfigService(builder.Services, ConnString);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddTransient<IFileUploader,FileUploader>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();

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
