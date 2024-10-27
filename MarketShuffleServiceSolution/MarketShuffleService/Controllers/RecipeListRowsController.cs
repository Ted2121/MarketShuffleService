using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.Data_Access;
using MarketShuffleService.DTOs;
using MarketShuffleService.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace MarketShuffleService.Controllers;

public class RecipeListRowsController : ControllerBase
{
    private readonly IRecipeListRowRepository _recipeListRowRepository;
    private readonly IMapper _mapper;

    public RecipeListRowsController(IRecipeListRowRepository recipeListRowRepository, IMapper mapper)
    {
        _mapper = mapper;
        _recipeListRowRepository = recipeListRowRepository;
    }

    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<RecipeListRowDto>>> GetAllRecipeListRowsAsync()
    //{
    //    var recipeListRows = await _recipeListRowRepository.GetAllRecipeListRowsAsync();

    //    if (recipeListRows == null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(_mapper.Map<IEnumerable<RecipeListRowDto>>(recipeListRows));
    //}

    [HttpGet("{recipeListId}")]
    public async Task<ActionResult<IEnumerable<RecipeListRowDto>>> GetAllRecipeListRowsByRecipeListIdAsync(string recipeListId)
    {
        if (String.IsNullOrEmpty(recipeListId))
        {
            return BadRequest("Recipe List Id not allowed empty");
        }

        var recipeListRows = await _recipeListRowRepository.GetAllRecipeListRowsByRecipeListId(recipeListId);

        if (recipeListRows == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<RecipeListRowDto>>(recipeListRows));
    }

    [HttpGet("{resourceName}")]
    public async Task<ActionResult<IEnumerable<RecipeListRowDto>>> GetAllRecipeListRowsByResourceNameAsync(string resourceName)
    {
        if (String.IsNullOrEmpty(resourceName))
        {
            return BadRequest("RsourceName not allowed empty");
        }

        var recipeListRows = await _recipeListRowRepository.GetAllRecipeListRowsByResourceName(resourceName);

        if (recipeListRows == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<RecipeListRowDto>>(recipeListRows));
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<RecipeListRowDto>> GetRecipeListRowByIdAsync(string id)
    {
        if (String.IsNullOrEmpty(id))
        {
            return BadRequest("Recipe List row Id not allowed empty");
        }

        var recipeListRow = await _recipeListRowRepository.GetRecipeListRowByIdAsync(id);

        if (recipeListRow == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<RecipeListRowDto>(recipeListRow));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateRecipeListRowAsync(RecipeListRowDto recipeListRowDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        recipeListRowDto.Id = Guid.NewGuid().ToString();

        var returnedId = await _recipeListRowRepository.CreateRecipeListRowAsync(_mapper.Map<RecipeListRow>(recipeListRowDto));

        if (returnedId == null)
        {
            return BadRequest();
        }

        return Ok(returnedId);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteRecipeListRowAsync(string id)
    {
        if (String.IsNullOrEmpty(id))
        {
            return BadRequest("Recipe List row Id not allowed empty");
        }

        if (await _recipeListRowRepository.GetRecipeListRowByIdAsync(id) == null)
        {
            return NotFound();
        }

        if (!await _recipeListRowRepository.DeleteRecipeListRowAsync(id))
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateRecipeListRowAsync(RecipeListRowDto recipeListRowDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _recipeListRowRepository.UpdateRecipeListRowAsync(_mapper.Map<RecipeListRow>(recipeListRowDto)))
        {
            return BadRequest();
        }

        return NoContent();
    }
}
