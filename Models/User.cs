namespace WsuTriangle.AttendanceTracker.Models;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "Member"; // Default to Member, could also be Admin
    public bool IsApproved { get; set; } = false; // Has to be approved by an admin first
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
