using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.Data_Access;
using MarketShuffleService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MarketShuffleService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipeListsController : ControllerBase
{
    private readonly IRecipeListRepository _recipeListRepository;
    private readonly IMapper _mapper;

    public RecipeListsController(IRecipeListRepository recipeListRepository, IMapper mapper)
    {
        _mapper = mapper;
        _recipeListRepository = recipeListRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeListDto>>> GetAllRecipeListsAsync()
    {
        var recipeLists = await _recipeListRepository.GetAllRecipeListsAsync();

        if (recipeLists == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<RecipeListDto>>(recipeLists));
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<RecipeListDto>> GetRecipeListByIdAsync(string id)
    {
        var recipeList = await _recipeListRepository.GetRecipeListByIdAsync(id);

        if (recipeList == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<RecipeListDto>(recipeList));
    }

    [Route("name/{name}")]
    [HttpGet]
    public async Task<ActionResult<RecipeListDto>> GetRecipeListByNameAsync(string name)
    {
        var recipeList = await _recipeListRepository.GetRecipeListByNameAsync(name);

        if (recipeList == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<RecipeListDto>(recipeList));
    }

    [Route("search/{search}")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeListDto>>> GetRecipeListsBySearchString(string search)
    {
        var recipeLists = await _recipeListRepository.SearchRecipeListByName(search);

        if (!recipeLists.Any())
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<RecipeListDto>>(recipeLists));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateRecipeListAsync(RecipeListDto recipeListDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        recipeListDto.Id = Guid.NewGuid().ToString();

        var returnedId = await _recipeListRepository.CreateRecipeListAsync(_mapper.Map<RecipeList>(recipeListDto));

        if (returnedId == null)
        {
            return BadRequest();
        }

        return Ok(returnedId);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteRecipeListAsync(string id)
    {
        if (await _recipeListRepository.GetRecipeListByIdAsync(id) == null)
        {
            return NotFound();
        }

        if (!await _recipeListRepository.DeleteRecipeListAsync(id))
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateRecipeListAsync(RecipeListDto recipeListDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _recipeListRepository.UpdateRecipeListAsync(_mapper.Map<RecipeList>(recipeListDto)))
        {
            return BadRequest();
        }

        return NoContent();
    }
}
