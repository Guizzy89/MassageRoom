using MassageRoom.Data;
using MassageRoom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MassageRoom.Controllers;

public class BookingsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Bookings
    public async Task<IActionResult> Index()
    {
        var bookings = await _context.Bookings.Include(b => b.Service).ToListAsync();
        return View(bookings); // Показываем расписание и доступные слоты
    }

    // Реализация методов для добавления брони и просмотра деталей бронирования идёт далее
}