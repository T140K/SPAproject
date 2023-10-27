using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SPAproject.Data;
using SPAproject.Models;
using SPAproject.Models.ViewModels;
using System.Linq;
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

            var nick = user.Nick;
            if (nick == null)
            {
                throw new ArgumentException("nickname not found");
            }

            var existingGame = _context.Games.FirstOrDefault(g => g.User == nick && !g.GameFinished);
            if (existingGame != null)
            {
                return new GameViewModel()
                {
                    GameId = existingGame.GameId,
                    Answer = existingGame.Answer,
                    Messege = $"Continuing last game with {existingGame.GuessAmount} guesses"
                };
            }
            else
            {
                var publicId = Guid.NewGuid().ToString();
                var answer = new Random().Next(1, 101);

                _context.Add(new GameModel()
                {
                    GameId = publicId,
                    User = nick,
                    Answer = answer,
                    Date = DateTime.Now
                });
                _context.SaveChanges();

                return new GameViewModel() 
                { 
                    GameId = publicId, 
                    Answer = answer, 
                    Messege = "New game created"
                };
            }
        }
    }
}
