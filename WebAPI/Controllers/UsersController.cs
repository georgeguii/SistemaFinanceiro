using System.Text;
using Entities.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

using WebAPI.DTO;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddUser(LoginDTO loginDto)
    {
        if(string.IsNullOrWhiteSpace(loginDto.Email) ||
           string.IsNullOrWhiteSpace(loginDto.Password) ||
           string.IsNullOrWhiteSpace(loginDto.Cpf))
        {
            return BadRequest("Faltam alguns dados");
        }

        var user = new ApplicationUser
        {
            Email = loginDto.Email,
            UserName = loginDto.Email,
            CPF = loginDto.Cpf
        };

        var result = await _userManager.CreateAsync(user, loginDto.Password);

        if (result.Errors.Any())
        {
            return BadRequest(result.Errors);
        }

        //Confirmação via email
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        //Retorno do email
        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

        var responseReturn = await _userManager.ConfirmEmailAsync(user, code);

        if (responseReturn.Succeeded)
        {
            return Created("", "Usuário Adicionado com sucesso");
        }
        else
        {
            return BadRequest("Erro ao confiramr cadastro de usuário");
        }
    }
}
