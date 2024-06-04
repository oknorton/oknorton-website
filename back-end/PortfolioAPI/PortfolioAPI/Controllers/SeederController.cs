using Microsoft.AspNetCore.Mvc;
using PortfolioAPI;
//Author: Oliver Norton

namespace PortfolioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeederController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public SeederController(PortfolioDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SeedDatabase()
        {
            try
            {
                DBSeeder.Initialize(_context);
                return Ok("Database seeding completed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while seeding the database.");
            }
        }
    }
}