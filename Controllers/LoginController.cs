using Microsoft.AspNetCore.Mvc;
using APIAuth.Models;
using APIAuth.Repositories;
using APIAuth.Services;

namespace APIAuth;

[ApiController]
[Route("v1")]
public class LoginController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
    {
        // Recupera o usuário
        var user = UserRepository.Get(model.Username, model.Password);

        // Verifica se o usuário existe
        if (user == null) return NotFound(new { message = "Usuário ou senha inválidos." });

        // Gera o token
        var token = TokenService.GenerateToken(user);

        // Oculta a senha
        user.Password = "";

        // Retorna os dados
        return new 
        {
            user = user,
            token = token
        };
    }

}