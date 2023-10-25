using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPAproject.Data;
using SPAproject.Models;
using SPAproject.Models.ViewModels;
using System.Security.Claims;

namespace SPAproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public GameViewModel Post()
        {
            var publicId = Guid.NewGuid().ToString();

            var answer = new Random().Next(1, 100);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentException("userId not found");
            }

            _context.Add(new GameModel()
            {
                GameId = publicId,
                User = userId,
                Answer = answer,
                Date = DateTime.Now
            });
            _context.SaveChanges();

            return new GameViewModel() { GameId = publicId, Answer = answer,  };
        }
    }
}
