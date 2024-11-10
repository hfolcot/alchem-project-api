using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbEventsController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbEvent>>> GetDbEvents()
        {
            Console.WriteLine(context);
            Console.WriteLine(context.DbEvents);
            var dbEvents = await context.DbEvents.ToListAsync();
            return dbEvents;
        }
    }
}
