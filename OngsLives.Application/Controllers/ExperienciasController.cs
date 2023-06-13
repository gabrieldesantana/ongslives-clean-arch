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
public class ExperienciasController : ControllerBase
{
    private readonly IExperienciaService _service;
    public ExperienciasController(IExperienciaService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type = typeof(List<Experiencia>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        var experiencias = await _service.GetAllAsync();
        return Ok(experiencias);
    }

    [ProducesResponseType((200), Type = typeof(Experiencia))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id) 
    {
        var experiencia = await _service.GetByIdAsync(id);

        if (experiencia == null) 
            return NotFound();

        return Ok(experiencia);
    }

    [ProducesResponseType((201), Type = typeof(Experiencia))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("")]
    public async Task<IActionResult> PostAsync([FromBody] InputExperienciaModel inputExperienciaModel)
    {
        if (inputExperienciaModel == null)
            return BadRequest();
            
        await _service.InsertAsync(inputExperienciaModel);

        return Ok(inputExperienciaModel);
    }


    [ProducesResponseType((200), Type = typeof(EditExperienciaModel))]
    [ProducesResponseType((404))]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] EditExperienciaModel editExperienciaModel)
    {
        if (editExperienciaModel == null)
            return BadRequest();

        var experienciaEdit = await _service.UpdateAsync(id, editExperienciaModel);

        if (experienciaEdit == null)
            return BadRequest();

        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var experiencia = await _service.DeleteAsync(id);
        if (experiencia == false)
            return BadRequest();
            
        return NoContent();
    }

}