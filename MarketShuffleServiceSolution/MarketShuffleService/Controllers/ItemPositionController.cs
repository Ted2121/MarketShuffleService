using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.Data_Access;
using MarketShuffleService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketShuffleService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItemPositionController : ControllerBase
{
    private readonly IItemPositionRepository _itemPositionRepository;
    private readonly IMapper _mapper;

    public ItemPositionController(IItemPositionRepository itemPositionRepository, IMapper mapper)
    {
        _itemPositionRepository = itemPositionRepository;
        _mapper = mapper;
    }

    [Route("all")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemPositionDto>>> GetAllItemPositionsAsync()
    {
        var itemPositions = await _itemPositionRepository.GetAllItemPositionsAsync();

        if (itemPositions == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<ItemPositionDto>>(itemPositions));
    }

    [Route("allForItem/{id}")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemPositionDto>>> GetAllItemPositionsByParentIdAsync(string id)
    {
        var itemPositions = await _itemPositionRepository.GetAllItemPositionsByParentId(id);

        if (itemPositions == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<ItemPositionDto>>(itemPositions));
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<ItemPositionDto>> GetItemPositionByIdAsync(string id)
    {
        var itemPosition = await _itemPositionRepository.GetItemPositionByIdAsync(id);

        if (itemPosition == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ItemPositionDto>(itemPosition));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateItemPositionAsync(ItemPositionDto itemPositionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        itemPositionDto.Id = Guid.NewGuid().ToString();

        var returnedId = await _itemPositionRepository.CreateItemPositionAsync(_mapper.Map<ItemPosition>(itemPositionDto));

        if (returnedId == null)
        {
            return BadRequest();
        }

        return Ok(returnedId);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteItemPositionAsync(string id)
    {
        if (await _itemPositionRepository.GetItemPositionByIdAsync(id) == null)
        {
            return NotFound();
        }

        if (!await _itemPositionRepository.DeleteItemPositionAsync(id))
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateItemPositionAsync(ItemPositionDto itemPositionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _itemPositionRepository.UpdateItemPositionAsync(_mapper.Map<ItemPosition>(itemPositionDto)))
        {
            return BadRequest();
        }

        return NoContent();
    }
}
