using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.Data_Access;
using MarketShuffleService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketShuffleService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public ItemController(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    [Route("all")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllItemsAsync()
    {
        var items = await _itemRepository.GetAllItemsAsync();

        if (items == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<ItemDto>>(items));
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<ItemDto>> GetItemByIdAsync(string id)
    {
        var item = await _itemRepository.GetItemByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ItemDto>(item));
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateItemAsync(ItemDto itemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        itemDto.Id = Guid.NewGuid().ToString();

        var returnedId = await _itemRepository.CreateItemAsync(_mapper.Map<Item>(itemDto));

        if (returnedId == null)
        {
            return BadRequest();
        }

        return Ok(returnedId);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteItemAsync(string id)
    {
        if (await _itemRepository.GetItemByIdAsync(id) == null)
        {
            return NotFound();
        }

        if (!await _itemRepository.DeleteItemAsync(id))
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateItemAsync(ItemDto itemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _itemRepository.UpdateItemAsync(_mapper.Map<Item>(itemDto)))
        {
            return BadRequest();
        }

        return NoContent();
    }
}
