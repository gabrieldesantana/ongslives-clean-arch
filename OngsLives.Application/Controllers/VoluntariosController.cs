using Microsoft.AspNetCore.Mvc;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Application.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]

public class VoluntariosController : ControllerBase
{
    private readonly IVoluntarioService _service;
    public VoluntariosController(IVoluntarioService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type = typeof(List<Voluntario>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetTodosAsync()
    {
        var voluntarios = await _service.GetAllAsync();
        return Ok(voluntarios);
    }

    [ProducesResponseType((200), Type = typeof(Voluntario))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id) 
    {
        var voluntario = await _service.GetByIdAsync(id);

        if (voluntario == null) 
            return NotFound();

        return Ok(voluntario);
    }

    [ProducesResponseType((200), Type = typeof(Usuario))]
    [ProducesResponseType((404))]
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmailAsync(string email) 
    {
        var voluntario = await _service.GetByEmailAsync(email);

        if (voluntario == null) 
            return NotFound();

        return Ok(voluntario);
    }

    [ProducesResponseType((201), Type = typeof(Voluntario))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("")]
    public async Task<IActionResult> PostAsync([FromBody] InputVoluntarioModel inputVoluntarioModel)
    {
        if (inputVoluntarioModel == null)
            return BadRequest();

        await _service.InsertAsync(inputVoluntarioModel);

        return Ok(inputVoluntarioModel);
    }

    // [ProducesResponseType((201), Type = typeof(Imagem))]
    // [ProducesResponseType((400))]
    // [ProducesResponseType((404))]
    // [HttpPost("{id}/foto")]
    // public async Task<IActionResult> PostFotoAsync(int id, InputImagemModel inputImagemModel)
    // {
    //     var voluntario = await _service.PegarPorIdAsync(id);

    //     if (voluntario == null)
    //         return NotFound();

    //     var imagem = new Imagem 
    //     (
    //     voluntario.Id,
    //     inputImagemModel.Nome,
    //     inputImagemModel.Conteudo
    //     );

    //     if (imagem == null)
    //         return BadRequest();

    //     voluntario.AdicionarFoto(imagem);

    //     await _service.AdicionarFotoAsync(voluntario);

    //     return NoContent();
    // }

    [ProducesResponseType((200), Type = typeof(EditVoluntarioModel))]
    [ProducesResponseType((404))]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] EditVoluntarioModel editVoluntarioModel)
    {
        if (editVoluntarioModel == null)
            return BadRequest();

        var voluntarioEdit = await _service.UpdateAsync(id, editVoluntarioModel);

        if (voluntarioEdit == null)
            return BadRequest();

        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var voluntario = await _service.DeleteAsync(id);

        if (voluntario == false)
            return BadRequest();
            
        return NoContent();
    }

}