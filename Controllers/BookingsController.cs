using MassageRoom.Data;
using MassageRoom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
        return View(bookings);
    }

    // GET: Bookings/Details/{id}
    public async Task<IActionResult> Details(int id)
    {
        var booking = await _context.Bookings.Include(b => b.Service).FirstOrDefaultAsync(m => m.Id == id);
        if (booking == null)
        {
            return NotFound();
        }
        return View(booking);
    }

    // GET: Bookings/Create
    public IActionResult Create()
    {
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
        return View();
    }

    // POST: Bookings/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FullName,PhoneNumber,Comment,StartTime,EndTime,ServiceId")] Booking booking)
    {
        if (ModelState.IsValid)
        {
            _context.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", booking.ServiceId);
        return View(booking);
    }

    // GET: Bookings/Edit/{id}
    public async Task<IActionResult> Edit(int id)
    {
        var booking = await _context.Bookings.Include(b => b.Service).FirstOrDefaultAsync(m => m.Id == id);
        if (booking == null)
        {
            return NotFound();
        }
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", booking.ServiceId);
        return View(booking);
    }

    // POST: Bookings/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,PhoneNumber,Comment,StartTime,EndTime,ServiceId")] Booking booking)
    {
        if (id != booking.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(booking);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bookings.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", booking.ServiceId);
        return View(booking);
    }

    // GET: Bookings/Delete/{id}
    public async Task<IActionResult> Delete(int id)
    {
        var booking = await _context.Bookings.Include(b => b.Service).FirstOrDefaultAsync(m => m.Id == id);
        if (booking == null)
        {
            return NotFound();
        }
        return View(booking);
    }

    // POST: Bookings/Delete/{id}
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}