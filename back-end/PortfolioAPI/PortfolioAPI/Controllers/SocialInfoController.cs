using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialInfoController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public SocialInfoController(PortfolioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialInfoResponseDto>>> GetSocialInfos()
        {
            var socialInfos = await _context.SocialInfos.Select(si => new SocialInfoResponseDto
            {
                SocialInfoId = si.Id,
                Platform = si.Platform,
                Url = si.Url,
                UserId = si.UserId
            }).ToListAsync();

            return socialInfos;
        }

        [HttpPost("{userId}/AddSocialInfo")]
        public async Task<IActionResult> AddSocialInfoToUser(int userId, [FromBody] SocialInfoDto socialInfoDto)
        {
            var user = await _context.Users.Include(u => u.SocialInfos).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var socialInfo = new SocialInfo
            {
                Platform = socialInfoDto.Platform,
                Url = socialInfoDto.Url
            };

            user.SocialInfos.Add(socialInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{userId}/EditSocialInfo/{socialInfoId}")]
        public async Task<IActionResult> EditUserSocialInfo(int userId, int socialInfoId, [FromBody] SocialInfoDto socialInfoDto)
        {
            var user = await _context.Users.Include(u => u.SocialInfos).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var existingSocialInfo = user.SocialInfos.FirstOrDefault(si => si.Id == socialInfoId);
            if (existingSocialInfo == null)
            {
                return NotFound("SocialInfo not found in user's social infos.");
            }

            existingSocialInfo.Platform = socialInfoDto.Platform;
            existingSocialInfo.Url = socialInfoDto.Url;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{userId}/RemoveSocialInfo/{socialInfoId}")]
        public async Task<IActionResult> RemoveSocialInfoFromUser(int userId, int socialInfoId)
        {
            var user = await _context.Users.Include(u => u.SocialInfos).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var socialInfo = user.SocialInfos.FirstOrDefault(si => si.Id == socialInfoId);
            if (socialInfo == null)
            {
                return NotFound("SocialInfo not found in user's social infos.");
            }

            user.SocialInfos.Remove(socialInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class SocialInfoDto
    {
        public string Platform { get; set; }
        public string Url { get; set; }
    }
    public class SocialInfoResponseDto
    {
        public int SocialInfoId { get; set; }
        public string Platform { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
