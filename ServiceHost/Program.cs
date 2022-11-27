using DiscountManagement.Configuration;
using InventoryManaement.Configuration;
using ShopManagement.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

ShopBootStrapper Shop = new ShopBootStrapper();
DiscountBootstrapper Discount = new DiscountBootstrapper();
InventoryBootStrapper Inventory = new InventoryBootStrapper();

var ConnString = builder.Configuration.GetSection("ConnString")["OnlineShopDb"];

Shop.ConfigService(builder.Services, ConnString);
Discount.ConfigService(builder.Services, ConnString);
Inventory.ConfigService(builder.Services, ConnString);

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
