using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.Data_Access;
using MarketShuffleService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketShuffleService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public PlayerController(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAllPlayersAsync()
    {
        var players = await _playerRepository.GetAllPlayersAsync();

        if (players == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<PlayerDto>>(players));
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<PlayerDto>> GetPlayerByIdAsync(string id)
    {
        var player = await _playerRepository.GetPlayerByIdAsync(id);

        if (player == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PlayerDto>(player));
    }

    [Route("search/{search}")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayersBySearchString(string search)
    {
        var players = await _playerRepository.SearchPlayerByName(search);

        if (!players.Any())
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<PlayerDto>>(players));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreatePlayerAsync(PlayerDto playerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        playerDto.Id = Guid.NewGuid().ToString();

        var returnedId = await _playerRepository.CreatePlayerAsync(_mapper.Map<Player>(playerDto));

        if (returnedId == null)
        {
            return BadRequest();
        }

        return Ok(returnedId);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> DeletePlayerAsync(string id)
    {
        if (await _playerRepository.GetPlayerByIdAsync(id) == null)
        {
            return NotFound();
        }

        if (!await _playerRepository.DeletePlayerAsync(id))
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdatePlayerAsync(PlayerDto playerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _playerRepository.UpdatePlayerAsync(_mapper.Map<Player>(playerDto)))
        {
            return BadRequest();
        }

        return NoContent();
    }
}
