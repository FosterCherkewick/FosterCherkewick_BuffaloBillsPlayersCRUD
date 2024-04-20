using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BuffaloBillsPlayersCRUD.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using BuffaloBillsPlayersCRUD.Models;



namespace BuffaloBillsPlayersCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuffaloBillsPlayerController : ControllerBase
    {
        private readonly IBuffaloBillsPlayerService _playerService;

        public BuffaloBillsPlayerController(IBuffaloBillsPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            return Ok(_playerService.GetAllPlayers(isActive));

        }
        //hhtp get request
        [HttpGet]
        [Route("{playerNumber}")]
        public IActionResult Get(int playerNumber)
        {
            var player = _playerService.GetPlayerByNumber(playerNumber);
            if(player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
        //http post request
        [HttpPost]
        public IActionResult Post(AddUpdateDeleteOurPlayer playerObject)
        {
            var player = _playerService.AddPlayer(playerObject);
            if(player == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Player added Successfully!",
                playerNumber = player.PlayerNumber
            });
            
        }
    }

    


}
