using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Domain.Interfaces.IExpense;
using Domain.Interfaces.IServices;
using Domain.Interfaces.ICategory;
using Domain.Services;
using Entities.Entitites;

namespace WebAPI.Controllers;
[Route("[controller]/[action]")]
[ApiController]
[Authorize]
public class ExpenseController : ControllerBase
{
    private readonly InterfaceExpense _interfaceExpense;
    private readonly IExpenseService _iExpenseService;

    public ExpenseController(InterfaceExpense interfaceExpense, IExpenseService iExpenseService)
    {
        _interfaceExpense = interfaceExpense;
        _iExpenseService = iExpenseService;
    }

    [HttpGet("{userEmail}")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> ListUserCategories(string userEmail)
    {
        return Ok(await _interfaceExpense.ListUserExpenses(userEmail));
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var expense = await _interfaceExpense.GetById(id);

        if (expense is null)
            return NotFound("Não foi encontrado esse ID de despesa");

        return Ok(expense);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> AddExpense(Expense expense)
    {
        await _iExpenseService.AddExpense(expense);
        return Created($"GetById/{expense.Id}", expense);
    }

    [HttpPut]
    [Produces("application/json")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> UpdateExpense(Expense expense)
    {
        await _iExpenseService.UpdateExpense(expense);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var expense = await _interfaceExpense.GetById(id);
        if (expense is null)
            return NotFound(new { detail = "Não foi encontrado esse ID de despesa" });

        await _interfaceExpense.Remove(expense);
        return NoContent();
    }

    [HttpGet("{userEmail}")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> LoadGraphics(string userEmail)
    {
        var graphics = await _iExpenseService.LoadGraphics(userEmail);

        if (graphics is null)
            return NotFound("Email de usuário não encontrado");

        return Ok(graphics);
    }
}
