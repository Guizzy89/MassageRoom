using System.ComponentModel.DataAnnotations.Schema;

namespace MassageRoom.Models;

public class Booking
{
    public int Id { get; set; }

    // Информация о клиенте
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Comment { get; set; } = "";

    // Время бронирования
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    // Связь с услугами
    public int ServiceId { get; set; }
    public virtual Service Service { get; set; } = null!;
}