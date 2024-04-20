using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BuffaloBillsPlayersCRUD.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using BuffaloBillsPlayersCRUD.Models;
using System.Numerics;



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
        //http put/ update request
        [HttpPut]
        [Route("playerNumber")]
        public IActionResult Put([FromRoute] int playerNumber, [FromBody] AddUpdateDeleteOurPlayer playerObject)
        {
            var player = _playerService.UpdatePlayer(playerNumber, playerObject);
            if (player == null)
            {
                return NotFound();

            }
            return Ok(new
            {
                message = "Player info has been updated Successfully!",
                playerNumber = player.PlayerNumber
            });
        }

        //http delete request
        [HttpDelete]
        [Route("playerNumber")]
        public IActionResult Delete([FromRoute] int playerNumber)
        {
            if (!_playerService.DeletePlayerByNumber(playerNumber))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Player Has Been Successfully Cut From The Roster!",
                playerNumber = playerNumber
            });
        }
    }

    


}
