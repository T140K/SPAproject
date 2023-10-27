using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAproject.Data;
using SPAproject.Models.ViewModels;
using System.Security.Claims;

namespace SPAproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatisticsViewModel>>> Get()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                throw new ArgumentException("userId not found");
            }

            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentException("user not found");
            }

            var userStats = await _context.Games
                .Where(u => u.User == user.Nick && u.GameFinished == true)
                .Select(u => new StatisticsViewModel()
                {
                    User = u.User,
                    GuessCount = u.GuessAmount,
                    Answer = u.Answer,
                    Date = u.Date.Date.ToString()
                }).OrderByDescending(u => u.Date)
                .ToListAsync();


            return userStats;
        }
    }
}
