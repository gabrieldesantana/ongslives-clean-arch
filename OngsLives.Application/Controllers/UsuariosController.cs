using Microsoft.AspNetCore.Mvc;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Application.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
//[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;
    public UsuariosController(IUsuarioService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type = typeof(List<Usuario>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        var usuarios = await _service.GetAllAsync();
        return Ok(usuarios);
    }

    [ProducesResponseType((200), Type = typeof(Usuario))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id) 
    {
        var usuario = await _service.GetByIdAsync(id);

        if (usuario == null) 
            return NotFound();

        return Ok(usuario);
    }

    [ProducesResponseType((200), Type = typeof(Usuario))]
    [ProducesResponseType((404))]
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmailAsync(string email) 
    {
        var usuario = await _service.GetByEmailAsync(email);

        if (usuario == null) 
            return NotFound();

        return Ok(usuario);
    }

    [ProducesResponseType((201), Type = typeof(Usuario))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("")]
    public async Task<IActionResult> PostAsync([FromBody] InputUsuarioModel inputUsuarioModel)
    {
        if (inputUsuarioModel == null)
            return BadRequest();

        await _service.InsertAsync(inputUsuarioModel);

        return Ok(inputUsuarioModel);
    }

    [ProducesResponseType((200), Type = typeof(EditUsuarioModel))]
    [ProducesResponseType((404))]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id,[FromBody] EditUsuarioModel editUsuarioModel)
    {
        if (editUsuarioModel == null)
            return BadRequest();

        var usuarioEdit = await _service.UpdateAsync(id, editUsuarioModel);

        if (usuarioEdit == null)
            return BadRequest();

        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpGet("changeStatus/{id}")]
    public async Task<IActionResult> UpdateSituationAsync(int id)
    {
        var usuario = await _service.UpdateSituationAsync(id);

        if (usuario == false)
            return BadRequest();
            
        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var usuario = await _service.DeleteAsync(id);

        if (usuario == false)
            return BadRequest();
            
        return NoContent();
    }

}