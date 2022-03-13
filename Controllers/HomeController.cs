using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APIAuth.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo"; // Qualquer pessoa pode acessar esse endpoint

    [HttpGet]
    [Route("authenticated")]
    [Authorize] // Necessita de autenticação
    public string Authenticated() => $"Autenticado: {User.Identity.Name}"; // Somente quem estiver logado

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "secretary,manager")] // Necessita de autenticação e estar dentro do Role
    public string Employee() => $"Funcionário: {User.Identity.Name}";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "manager")] // Necessita de autenticação e ser manager
    public string Manager() => $"Manager: {User.Identity.Name}";
}
