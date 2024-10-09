using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WsuTriangle.AttendanceTracker.Models;

namespace WsuTriangle.AttendanceTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController(AppDbContext db) : ControllerBase
{
    [HttpPost]
    // [Authorize(Roles = "Member")] // will figure out later
    public async Task MarkAttendance(int eventId, int userId)
    {
        // var userId = GetUserIdFromToken() // Extract user ID from JWT // will figure out later
        var attendance = new Attendance
        {
            EventId = eventId,
            UserId = userId
        };

        db.Attendances.Add(attendance);
        await db.SaveChangesAsync();
    }

    [HttpGet]
    [Route("event-attendance")]
    // [Authorize(Roles = "Admin")]
    public IEnumerable<Attendance> GetAttendanceForEvent(int eventId)
    {
        return db.Attendances
            .Where(a => a.EventId == eventId)
            .Include(a => a.User)
            .ToList();
    }

    [HttpGet]
    [Route("user-attendance")]
    public IEnumerable<Attendance> GetAttendanceForUser(int userId)
    {
        return db.Attendances
            .Where(a => a.UserId == userId)
            .Include(a => a.Event)
            .ToList();
    }

    // private int GetUserIdFromToken() {} // will figure out later
}