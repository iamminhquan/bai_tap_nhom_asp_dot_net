using BaiTapNhom02_Lan_02.Database;
using BaiTapNhom02_Lan_02.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Minh Quân.
// Trigger session.
// Ngày chỉnh sửa: 11/10/2025 - 4:38 PM.

// Trigger session.
builder.Services.AddSession(options =>
{
    // Expire in 15 minutes.
    options.IdleTimeout = TimeSpan.FromMinutes(15);
});

// DI Register.
builder.Services.AddScoped<ConnectDatabase>();
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<TagNameServices>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Minh Quân.
// Thêm app.UseSession();.
// Ngày chỉnh sửa: 11/10/2025 - 4:39 PM.
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
