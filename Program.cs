using MassageRoom.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Регистрация контекста базы данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
                         "Server=(localdb)\\mssqllocaldb;Database=MassageRoomDB;Trusted_Connection=True;")
);

// Добавляем поддержку контроллеров MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Средства безопасности и перенаправления запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Включаем политику строгого транспорта (HTTPS)
}

// Промежуточные уровни обработки запросов
app.UseHttpsRedirection(); // Принудительное перенаправление на HTTPS
app.UseStaticFiles(); // Служит статическими ресурсами (CSS, JS)

app.UseRouting(); // Маршрутизация запросов

app.UseAuthentication(); // Аутентификация (при наличии)
app.UseAuthorization(); // Авторизация (при наличии)

// Регистрация маршрутов контроллеров
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Запуск приложения
app.Run();