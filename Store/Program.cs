using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Store.Data;
using Store.Data.Interfaces;
using Store.Data.Models;
using Store.Data.Repository;
using Store.Service;

var builder = WebApplication.CreateBuilder(args);

// Настройка Serilog для логирования в файл
var logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Добавляем поддержку сессий
builder.Services.AddDistributedMemoryCache(); // Включение кэширования в памяти для сессий
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Время жизни сессии
    options.Cookie.HttpOnly = true; // Безопасность для сессий (только HTTP)
    options.Cookie.IsEssential = true; // Сессии необходимы для функционирования сайта
});


builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllersWithViews();

// Получение строки подключения из appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Регистрация DbContext с использованием строки подключения
builder.Services.AddDbContext<AppDBContent>(options =>
    options.UseSqlServer(connectionString));

// Регистрация репозиториев и других сервисов
builder.Services.AddScoped<IAllProducts, ProductRepository>();
builder.Services.AddScoped<IProductCategory, CategoryRepository>();

// Регистрация Identity с использованием кастомной модели пользователя ApplicationUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDBContent>()
    .AddDefaultTokenProviders();

// Кастомная фабрика для добавления claim'ов
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsPrincipalFactory>();

// Настройка параметров Identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; // Требование наличия цифры
    options.Password.RequireLowercase = true; // Требование наличия строчной буквы
    options.Password.RequireUppercase = true; // Требование наличия заглавной буквы
    options.Password.RequireNonAlphanumeric = false; // Требование наличия специального символа
    options.Password.RequiredLength = 5; // Минимальная длина пароля
    options.Password.RequiredUniqueChars = 2; // Количество уникальных символов
});

// Настройка сессий
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Регистрация сервисов в DI контейнере
builder.Services.AddControllersWithViews();

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

// Подключение сессий
app.UseSession();

// Аутентификация и авторизация
app.UseAuthentication();
app.UseAuthorization();

// Подключение middleware для работы с сессиями
app.UseSession();

// Вызов метода инициализации данных
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDBContent>();
    DBObjects.Initial(context);
}

// Маршрутизация
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
