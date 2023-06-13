using Microsoft.AspNetCore.Mvc;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;

namespace OngsLives.Application.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class OngFinanceirosController : ControllerBase
{
    private readonly IOngFinanceiroService _service;
    public OngFinanceirosController(IOngFinanceiroService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type = typeof(List<OngFinanceiro>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        var ongFinanceiros = await _service.GetAllAsync();
        return Ok(ongFinanceiros);
    }

    [ProducesResponseType((200), Type = typeof(OngFinanceiro))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id) 
    {
        var ongFinanceiro = await _service.GetByIdAsync(id);

        if (ongFinanceiro == null) 
            return NotFound();

        return Ok(ongFinanceiro);
    }

    [ProducesResponseType((200), Type = typeof(EditOngFinanceiroModel))]
    [ProducesResponseType((404))]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] EditOngFinanceiroModel ongFinanceiro)
    {
        if (ongFinanceiro == null)
            return BadRequest();

        var ongFinanceiroEdit = await _service.UpdateAsync(id, ongFinanceiro);

        if (ongFinanceiroEdit == null)
            return BadRequest();

        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var ongFinanceiro = await _service.DeleteAsync(id);
        if (ongFinanceiro == false)
            return BadRequest();
            
        return NoContent();
    }

}