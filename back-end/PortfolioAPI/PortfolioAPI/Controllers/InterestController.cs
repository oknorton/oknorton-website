using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public InterestController(PortfolioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInterest>>> GetInterests()
        {
            return await _context.Interests.ToListAsync();
        }

        [HttpPost("{userId}/AddInterest")]
        public async Task<IActionResult> AddInterestToUser(int userId, [FromBody] string description)
        {
            var user = await _context.Users.Include(u => u.Interests).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (user.Interests.Any(i => i.Description == description))
            {
                return BadRequest("User already has this interest.");
            }

            var userInterest = new UserInterest { Description = description };
            user.Interests.Add(userInterest);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{userId}/RemoveInterest/{userInterestId}")]
        public async Task<IActionResult> RemoveInterestFromUser(int userId, int userInterestId)
        {
            var user = await _context.Users.Include(u => u.Interests).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var userInterest = user.Interests.FirstOrDefault(i => i.Id == userInterestId);
            if (userInterest == null)
            {
                return NotFound("Interest not found in user's interests.");
            }

            user.Interests.Remove(userInterest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{userId}/EditInterest/{userInterestId}")]
        public async Task<IActionResult> EditUserInterest(int userId, int userInterestId, [FromBody] string description)
        {
            var user = await _context.Users.Include(u => u.Interests).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var existingUserInterest = user.Interests.FirstOrDefault(i => i.Id == userInterestId);
            if (existingUserInterest == null)
            {
                return NotFound("Interest not found in user's interests.");
            }

   
            existingUserInterest.Description = description;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
