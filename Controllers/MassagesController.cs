using MassageRoom.Data;
using MassageRoom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MassageRoom.Controllers;

public class MassagesController : Controller
{
    private readonly ApplicationDbContext _context;

    public MassagesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Massages
    public async Task<IActionResult> Index()
    {
        var services = await _context.Services.ToListAsync();
        return View(services); // Возвращает представление с перечнем услуг
    }

    // Другие методы CRUD (добавлять, редактировать, удалять услуги) реализуются позже
}