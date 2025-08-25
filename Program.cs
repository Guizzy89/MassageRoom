using MassageRoom.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ����������� ��������� ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
                         "Server=(localdb)\\mssqllocaldb;Database=MassageRoomDB;Trusted_Connection=True;")
);

// ��������� ��������� ������������ MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// �������� ������������ � ��������������� ��������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // �������� �������� �������� ���������� (HTTPS)
}

// ������������� ������ ��������� ��������
app.UseHttpsRedirection(); // �������������� ��������������� �� HTTPS
app.UseStaticFiles(); // ������ ������������ ��������� (CSS, JS)

app.UseRouting(); // ������������� ��������

app.UseAuthentication(); // �������������� (��� �������)
app.UseAuthorization(); // ����������� (��� �������)

// ����������� ��������� ������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// ������ ����������
app.Run();