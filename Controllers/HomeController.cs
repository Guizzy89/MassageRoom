using Microsoft.AspNetCore.Mvc;

namespace MassageRoom.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(); // Вернуть представление главной страницы
    }
}