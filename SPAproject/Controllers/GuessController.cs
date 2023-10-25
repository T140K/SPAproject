using Microsoft.AspNetCore.Mvc;
using SPAproject.Models.ViewModels;
using SPAproject.Models;
using SPAproject.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace SPAproject.Controllers
{
    [Route("api/[controller]/{gameId}/{guess}")]
    [ApiController]
    [Authorize]
    public class GuessController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GuessController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public GuessViewModel Get(string gameId, int guess)
        {
            var game = _context.Games.Where(g => g.GameId == gameId).FirstOrDefault();
            if (game == null)
            {
                throw new Exception("game not found");

            }

            if (game.GameFinished)
            {
                return new GuessViewModel() { Response = "This game is over already, start a new one :D" };
            }

            if (guess < 1 || guess > 3)
            {
                return new GuessViewModel() { Response = "Guess only numbers between 1 and 3!!" };
            }

            if (guess == game.Answer)
            {
                game.GuessAmount++;
                game.GameFinished = true;
                _context.SaveChanges();
                return new GuessViewModel() { Response = $"good job you got it in {game.GuessAmount} guesses"};
            }
            else if (guess < game.Answer)
            {
                game.GuessAmount++;
                _context.SaveChanges();
                return new GuessViewModel() { Response = $"You guessed too low" };
            }
            else if (guess > game.Answer)
            {
                game.GuessAmount++;
                _context.SaveChanges();
                return new GuessViewModel() { Response = $"You guessed too high" };
            }

            return new GuessViewModel() { Response ="something went wrong, you should start a new game" };
        }
    }
}
