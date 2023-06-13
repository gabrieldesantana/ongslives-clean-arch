using Microsoft.AspNetCore.Mvc;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Application.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class VagasController : ControllerBase
{
    private readonly IVagaService _service;
    public VagasController(IVagaService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type= typeof(List<Vaga>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        var vagas = await _service.GetAllAsync();
        return Ok(vagas);
    }

    [ProducesResponseType((200), Type= typeof(Vaga))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var vaga = await _service.GetByIdAsync(id);

        if (vaga == null)
            return NotFound();

        return Ok(vaga);
    }

    [ProducesResponseType((201), Type= typeof(Vaga))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("")]
    public async Task<IActionResult> PostAsync([FromBody] InputVagaModel inputVagaModel)
    {
        if (inputVagaModel == null)
            return BadRequest();
        
        await _service.InsertAsync(inputVagaModel);

        return Ok(inputVagaModel);
    }

    [ProducesResponseType((200), Type= typeof(Vaga))]
    [ProducesResponseType((404))]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] EditVagaModel vaga)
    {
        if (vaga == null)
            return BadRequest();

        var vagaEdit = await _service.UpdateAsync(id, vaga);

        if (vagaEdit == null)
            return BadRequest();
        
        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var vaga = await _service.DeleteAsync(id);
        if (vaga == false)
            return BadRequest();
            
        return NoContent();
    }

}