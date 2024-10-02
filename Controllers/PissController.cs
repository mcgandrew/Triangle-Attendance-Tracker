using Microsoft.AspNetCore.Mvc;
using WsuTriangle.AttendanceTracker.Models;

namespace WsuTriangle.AttendanceTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class PissController(AppDbContext db) : ControllerBase {

    [HttpPost]
    public async Task ConsumeWellington(string name, int beefType)
    {
        var wellington = new BeefWellington
        {
            Name = name,
            BeefType = beefType,
            Description = "beefy"
        };

        db.BeefWellingtons.Add(wellington);
        await db.SaveChangesAsync();
    }

    [HttpGet]
    public IEnumerable<BeefWellington> PissWellington(int id)
    {
        return db.BeefWellingtons
            .Where(bw => bw.Id == id)
            .ToList();
    }
}
