using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAproject.Data;
using SPAproject.Models.ViewModels;

namespace SPAproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighscoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HighscoreController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<HighscoreAllViewModel>> Get()
        {
            DateTime today = DateTime.Today;

            var query = new HighscoreAllViewModel
            {
                Today = await _context.Games
                    .Where(g => g.GameFinished == true && g.Date.Date == today)
                    .Select(g => new HighscoreViewModel
                    {
                        User = g.User,
                        GuessAmount = g.GuessAmount,
                        Date = g.Date
                    }).OrderBy(g => g.GuessAmount)
                    .ToListAsync(),
                AllTime = await _context.Games
                    .Where(g => g.GameFinished == true)
                    .Select(g => new HighscoreViewModel
                    {
                        User = g.User,
                        GuessAmount = g.GuessAmount,
                        Date = g.Date
                    }).OrderBy(g => g.GuessAmount)
                    .ToListAsync(),

            };
            if (query.Today.Count == 0 && query.AllTime.Count == 0)
            {
                throw new ArgumentException("no highscores found");
            }

            return query;
        }
    }
}
