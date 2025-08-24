using System.Threading.Tasks;
using AnimeTrack.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class DatabaseController : ControllerBase
{
    protected AnimeContext dbContext;

    public DatabaseController(AnimeContext context)
    {
        dbContext = context;
    }

    [HttpGet]
    public async Task<IActionResult> CreateDatabase()
    {
        await dbContext.Database.EnsureCreatedAsync();
        return Ok();
    }
}