using Microsoft.AspNetCore.Mvc;

using Entities.Entitites;
using Domain.Interfaces.IServices;
using Domain.Interfaces.IFinancialSystem;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers;
[Route("[controller]/[action]")]
[ApiController]
[Authorize]
public class FinancialSystemController : ControllerBase
{
	private readonly InterfaceFinancialSystem _interfaceFinancialSystem;
	private readonly IFinancialSystemService _iFinancialSystemService;

	public FinancialSystemController(InterfaceFinancialSystem interfaceFinancialSystem, IFinancialSystemService iFinancialSystemService)
	{
        _interfaceFinancialSystem = interfaceFinancialSystem;
        _iFinancialSystemService = iFinancialSystemService;
    }

	[HttpGet("{userEmail}")]
	[Produces("application/json")]
	[ProducesResponseType(200)]
	public async Task<IActionResult> UserSystemsList(string userEmail)
	{
		return Ok(await _interfaceFinancialSystem.ListUserSystems(userEmail));

    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetFinancialSystem(int id)
    {
        return Ok(await _interfaceFinancialSystem.GetById(id));
    }


    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> AddFinancialSystem(FinancialSystem financialSystem)
    {
        await _iFinancialSystemService.AddFinancialSystem(financialSystem);

        return Created("", financialSystem);

    }

    [HttpPut]
    [Produces("application/json")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> UpdateFinancialSystem(FinancialSystem financialSystem)
    {
        await _iFinancialSystemService.UpdateFinancialSystem(financialSystem);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteFinancialSystem(int id)
    {
        try
        {
            var financialSystem = await _interfaceFinancialSystem.GetById(id);

            if (financialSystem is null)
            {
                return NotFound("Não existe Sistema Financeiro com esse ID");
            }

            await _interfaceFinancialSystem.Remove(financialSystem);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(false);
        }
    }
}
