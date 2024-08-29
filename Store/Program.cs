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

// Настройка Serilog для логирования в файл
var logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Получение строки подключения из appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Регистрация DbContext с использованием строки подключения
builder.Services.AddDbContext<AppDBContent>(options =>
    options.UseSqlServer(connectionString));

// Регистрация Identity с использованием кастомной модели пользователя ApplicationUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDBContent>()
    .AddDefaultTokenProviders();

// Настройка требований к паролю
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; // Требование наличия цифры
    options.Password.RequireLowercase = true; // Требование наличия строчной буквы
    options.Password.RequireUppercase = true; // Требование наличия заглавной буквы
    options.Password.RequireNonAlphanumeric = false; // Требование наличия специального символа
    options.Password.RequiredLength = 5; // Минимальная длина пароля
    options.Password.RequiredUniqueChars = 2; // Количество уникальных символов
});

// Регистрация сервисов в DI контейнере
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAllProducts, ProductRepository>();
builder.Services.AddTransient<IProductCategory, CategoryRepository>();

var app = builder.Build();

// Обработка ошибок
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

// Аутентификация и авторизация
app.UseAuthentication();
app.UseAuthorization();

// Инициализация базы данных и применение миграций
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDBContent>();

        // Применение всех миграций
        context.Database.Migrate();

        // Инициализация базы данных
        DBObjects.Initial(context);
    }
    catch (Exception ex)
    {
        services.GetRequiredService<ILogger<Program>>().LogError(ex, "Произошла ошибка при инициализации базы данных.");
    }
}

// Маршрутизация
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
