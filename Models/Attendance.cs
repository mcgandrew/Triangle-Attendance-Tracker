namespace WsuTriangle.AttendanceTracker.Models;

public class Attendance
{
    public int AttendanceId { get; set; }
    public int EventId { get; set; }
    public int UserId { get; set; }
    public DateTime AttendanceTime { get; set; } = DateTime.Now;

    // Navigation properties
    public virtual Event? Event { get; set; }
    public virtual User? User { get; set; }
}
