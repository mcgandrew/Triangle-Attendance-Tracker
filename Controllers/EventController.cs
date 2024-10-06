using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WsuTriangle.AttendanceTracker.Models;

namespace WsuTriangle.AttendanceTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController(AppDbContext db) : ControllerBase
{
    [HttpPost]
    // [Authorize(Roles = "Admin")] // will figure out later
    public async Task CreateEvent(string eventName, string eventDescription, DateTime eventDate, bool isRecurring)
    {
        var newEvent = new Event
        {
            EventName = eventName,
            EventDescription = eventDescription,
            EventDate = eventDate,
            IsRecurring = isRecurring,
            // CreatedBy = GetUserIdFromToken() // will make later
        };

        db.Events.Add(newEvent);
        await db.SaveChangesAsync();
    }

    [HttpGet]
    [Route("events")]
    public IEnumerable<Event> GetEvents()
    {
        return db.Events
            .ToList();
    }

    [HttpGet]
    [Route("event")]
    public IEnumerable<Event> GetEvent(int id)
    {
        return db.Events
            .Where(e => e.EventId == id);
    }
}
