using Microsoft.AspNetCore.Mvc;

using Domain.Interfaces.IServices;
using Domain.Interfaces.IUserFinancialSystem;
using Entities.Entitites;

namespace WebAPI.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class UserFinancialSystemController : ControllerBase
{
    private readonly InterfaceUserFinancialSystem _interfaceUserFinancialSystem;
    private readonly IUserFinancialSystemService _iUserFinancialSystemService;

    public UserFinancialSystemController(InterfaceUserFinancialSystem interfaceUserFinancialSystem, IUserFinancialSystemService iUserFinancialSystemService)
    {
        _interfaceUserFinancialSystem = interfaceUserFinancialSystem;
        _iUserFinancialSystemService = iUserFinancialSystemService;
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> ListSistemUsers(int idSystem)
    {
        return Ok(await _interfaceUserFinancialSystem.ListSistemUsers(idSystem));
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> AddUserFinancialSystem(int idSystem, string userEmail)
    {
        var user = new UserFinancialSystem
        { 
            SystemId = idSystem,
            UserEmail = userEmail,
            isAdmin = false,
            CurrentSystem = true
        };

        await _iUserFinancialSystemService.AddUserFinancialSystem(user);

        return Created("", "Usuário adicionado");
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> DeleteUserFinancialSystem(int id)
    {
        try
        {
            var userFinancialSystem = await _interfaceUserFinancialSystem.GetById(id);

            await _interfaceUserFinancialSystem.Remove(userFinancialSystem);

            return NoContent();
        }
        catch
        {
            return BadRequest("Ocorreu algum problema ao remover o Usuário do Sistema Financeiro");
        }
    }

}
