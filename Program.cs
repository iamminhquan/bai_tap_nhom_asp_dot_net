using BaiTapNhom02_Lan_02.Data;
using BaiTapNhom02_Lan_02.Database;
using BaiTapNhom02_Lan_02.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Minh Quân.
// Thêm cấu hình AppDbContext.
// Ngày chỉnh sửa: 28/10/2025 - 11:52 AM.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Minh Quân.
// Trigger session.
// Ngày chỉnh sửa: 11/10/2025 - 4:38 PM.

// Trigger session.
// Bật session
builder.Services.AddSession(options =>
{
    // Đặt session hết hạn trong 15 phút.
    // Expire in 15 minutes.
    options.IdleTimeout = TimeSpan.FromMinutes(15);
});

// DI Register.
builder.Services.AddScoped<ConnectDatabase>();
builder.Services.AddScoped<ProductServices>();

// thainguyen
// add CategoryServices 
// 13/10/25 21h30
builder.Services.AddScoped<CategoryServices>();
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
