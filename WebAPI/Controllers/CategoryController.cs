using Microsoft.AspNetCore.Mvc;

using Domain.Interfaces.ICategory;
using Domain.Interfaces.IServices;
using Entities.Entitites;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers;
[Route("[controller]/[action]")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly InterfaceCategory _interfaceCategory;
    private readonly ICategoryService _iCategoryService;

    public CategoryController(InterfaceCategory interfaceCategory, ICategoryService iCategoryService)
    {
        _interfaceCategory = interfaceCategory;
        _iCategoryService = iCategoryService;
    }

    [HttpGet("{userEmail}")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> ListUserCategories(string userEmail)
    {
        return Ok(await _interfaceCategory.ListUserCategories(userEmail));
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _interfaceCategory.GetById(id);

        if (category is null)
            return NotFound("Não foi encontrado esse ID de categoria");

        return Ok(category);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> AddCategory(Category category)
    {
        await _iCategoryService.AddCategory(category);
        return Created($"GetById/{category.Id}", category);
    }

    [HttpPut]
    [Produces("application/json")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> UpdateCategory(Category category)
    {
        await _iCategoryService.UpdateCategory(category);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _interfaceCategory.GetById(id);
        if (category is null)
            return NotFound("Não foi encontrado esse ID de categoria");

        await _interfaceCategory.Remove(category);
        return NoContent();
    }
}
