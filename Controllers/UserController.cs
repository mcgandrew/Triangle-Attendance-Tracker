using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WsuTriangle.AttendanceTracker.Models;

namespace WsuTriangle.AttendanceTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(AppDbContext db) : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task RegisterUser (string username, string password)
    {
        var user = new User
        {
            UserName = username,
            // PasswordHash = BCrypt.Net.BCrypt.HashPassword(password) // not working for some reason with dotnet build
            PasswordHash = password
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();
    }

    [HttpPost]
    [Route("approve")]
    // [Authorize(Roles = "Admin")]
    public async Task ApproveUser(int userId)
    {
        var user = await db.Users.FindAsync(userId);

        if (user == null)
        {
            return;
        }

        user.IsApproved = true;
        await db.SaveChangesAsync();
    }

    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        return db.Users
            .ToList();
    }
}
