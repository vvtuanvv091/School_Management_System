using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Nếu chưa đăng nhập, hệ thống sẽ đá về trang này
        options.LogoutPath = "/Account/Logout"; // Đường dẫn xử lý khi người dùng ấn Đăng xuất
        options.AccessDeniedPath = "/Account/AccessDenied"; // Đường dẫn khi người dùng không đủ quyền (VD: Học sinh cố vào trang của Admin)
        options.ExpireTimeSpan = TimeSpan.FromDays(1); // Thời gian đăng nhập tối đa (Ví dụ: 1 ngày)
        options.SlidingExpiration = true; // Tự động gia hạn thời gian nếu người dùng vẫn đang thao tác trên web
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); // LƯU Ý: Dòng này BẮT BUỘC phải nằm ngay TRÊN UseAuthorization()
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
