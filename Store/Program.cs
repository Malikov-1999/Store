using Store.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Store.Data.Models;
using Serilog;
using Serilog.Sinks.File;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// ��������� Serilog ��� ����������� � ����
var logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// ��������� ������ ����������� �� appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ����������� DbContext � �������������� ������ �����������
builder.Services.AddDbContext<AppDBContent>(options =>
    options.UseSqlServer(connectionString));

// ����������� Identity � �������������� ��������� ������ ������������ ApplicationUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDBContent>()
    .AddDefaultTokenProviders();

// ��������� ���������� � ������
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; // ���������� ������� �����
    options.Password.RequireLowercase = true; // ���������� ������� �������� �����
    options.Password.RequireUppercase = true; // ���������� ������� ��������� �����
    options.Password.RequireNonAlphanumeric = false; // ���������� ������� ������������ �������
    options.Password.RequiredLength = 5; // ����������� ����� ������
    options.Password.RequiredUniqueChars = 2; // ���������� ���������� ��������
});

// ����������� �������� � DI ����������
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAllProducts, ProductRepository>();
builder.Services.AddTransient<IProductCategory, CategoryRepository>();

var app = builder.Build();

// ��������� ������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();

// ������������� ���� ������ � ���������� ��������
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDBContent>();

        // ���������� ���� ��������
        context.Database.Migrate();

        // ������������� ���� ������
        DBObjects.Initial(context);
    }
    catch (Exception ex)
    {
        services.GetRequiredService<ILogger<Program>>().LogError(ex, "��������� ������ ��� ������������� ���� ������.");
    }
}

// �������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
