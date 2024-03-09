using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.Data_Access;
using MarketShuffleService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketShuffleService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GuildController : ControllerBase
{
    private readonly IGuildRepository _guildRepository;
    private readonly IMapper _mapper;

    public GuildController(IGuildRepository guildRepository, IMapper mapper)
    {
        _guildRepository = guildRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GuildDto>>> GetAllGuildsAsync()
    {
        var guilds = await _guildRepository.GetAllGuildsAsync();

        if (guilds == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<GuildDto>>(guilds));
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<GuildDto>> GetGuildByIdAsync(string id)
    {
        var guild = await _guildRepository.GetGuildByIdAsync(id);

        if (guild == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<GuildDto>(guild));
    }

    [Route("search/{search}")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GuildDto>>> GetGuildsBySearchString(string search)
    {
        var guilds = await _guildRepository.SearchGuildByName(search);

        if (!guilds.Any())
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<GuildDto>>(guilds));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateGuildAsync(GuildDto guildDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        guildDto.Id = Guid.NewGuid().ToString();

        var returnedId = await _guildRepository.CreateGuildAsync(_mapper.Map<Guild>(guildDto));

        if (returnedId == null)
        {
            return BadRequest();
        }

        return Ok(returnedId);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteGuildAsync(string id)
    {
        if (await _guildRepository.GetGuildByIdAsync(id) == null)
        {
            return NotFound();
        }

        if (!await _guildRepository.DeleteGuildAsync(id))
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateGuildAsync(GuildDto guildDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _guildRepository.UpdateGuildAsync(_mapper.Map<Guild>(guildDto)))
        {
            return BadRequest();
        }

        return NoContent();
    }
}
