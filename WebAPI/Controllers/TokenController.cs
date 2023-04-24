using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using WebAPI.DTO;
using WebAPI.Token;
using Entities.Entitites;

namespace WebAPI.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public TokenController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    [Produces("application/json")]
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> CreateToken(InputDTO input)
    {
        if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
            Unauthorized();

        var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, false, false);

        if (result.Succeeded)
        {
            var token = new TokenJWTBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                .AddSubject("George Guilherme")
                .AddIssuer("Teste.Securiry.Bearer")
                .AddAudience("Teste.Securiry.Bearer")
                .AddClaim("UsuarioAPINumero", "1")
                .AddExpiry(5)
                .Builder();

            return Created("", token.value);
        }
        else
        {
            return Unauthorized();
        }
    }
}
