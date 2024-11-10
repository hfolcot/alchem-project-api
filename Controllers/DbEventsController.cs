using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbEventsController(IDbEventRepository dbEventRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<DbEvent>> GetDbEvents()
        {
            var dbEvents = await dbEventRepository.GetDbEventsAsync();
            return dbEvents;
        }
    }
}
