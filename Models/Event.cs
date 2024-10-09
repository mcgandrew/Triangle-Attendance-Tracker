namespace WsuTriangle.AttendanceTracker.Models;

public class Event
{
    public int EventId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public string EventDescription { get; set; } = string.Empty;
    public bool IsRecurring { get; set; } = false;
    public int CreatedBy { get; set; } = 1; // Admin who created the event
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
