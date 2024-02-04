﻿using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.Data_Access;
using MarketShuffleService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketShuffleService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipeItemController : ControllerBase
{
    private readonly IRecipeItemRepository _recipeItemRepository;
    private readonly IMapper _mapper;

    public RecipeItemController(IRecipeItemRepository recipeItemRepository, IMapper mapper)
    {
        _recipeItemRepository = recipeItemRepository;
        _mapper = mapper;
    }

    [Route("all")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeItemDto>>> GetAllRecipeItemsAsync()
    {
        var recipeItems = await _recipeItemRepository.GetAllRecipeItemsAsync();

        if (recipeItems == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<RecipeItemDto>>(recipeItems));
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<RecipeItemDto>> GetRecipeItemByIdAsync(string id)
    {
        var recipeItem = await _recipeItemRepository.GetRecipeItemByIdAsync(id);

        if (recipeItem == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<RecipeItemDto>(recipeItem));
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateRecipeItemAsync(RecipeItemDto recipeItemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        recipeItemDto.Id = Guid.NewGuid().ToString();

        var returnedId = await _recipeItemRepository.CreateRecipeItemAsync(_mapper.Map<RecipeItem>(recipeItemDto));

        if (returnedId == null)
        {
            return BadRequest();
        }

        return Ok(returnedId);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteRecipeItemAsync(string id)
    {
        if (await _recipeItemRepository.GetRecipeItemByIdAsync(id) == null)
        {
            return NotFound();
        }

        if (!await _recipeItemRepository.DeleteRecipeItemAsync(id))
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateRecipeItemAsync(RecipeItemDto recipeItemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _recipeItemRepository.UpdateRecipeItemAsync(_mapper.Map<RecipeItem>(recipeItemDto)))
        {
            return BadRequest();
        }

        return NoContent();
    }
}
