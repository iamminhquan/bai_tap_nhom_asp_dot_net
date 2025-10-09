using BaiTapNhom02_Lan_02.Database;
using BaiTapNhom02_Lan_02.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// DI Register.
builder.Services.AddScoped<ConnectDatabase>();
builder.Services.AddScoped<ProductServices>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
