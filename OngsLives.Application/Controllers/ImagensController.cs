using Microsoft.AspNetCore.Mvc;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Application.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]

public class ImagensController : ControllerBase
{
    private readonly IImagemService _service;
    public ImagensController(IImagemService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type = typeof(List<Imagem>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        var imagens = await _service.GetAllAsync();
        return Ok(imagens);
    }

    [ProducesResponseType((200), Type = typeof(Imagem))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id) 
    {
        var imagem = await _service.GetByIdAsync(id);

        if (imagem == null) 
            return NotFound();

        return Ok(imagem);
    }

    [ProducesResponseType((201), Type = typeof(Imagem))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("")]
    public async Task<IActionResult> PostAsync([FromBody] InputImagemModel inputImagemModel)
    {
        if (inputImagemModel == null)
            return BadRequest();

        await _service.InsertAsync(inputImagemModel);

        return Ok(inputImagemModel);
    }

    [ProducesResponseType((200), Type = typeof(EditImagemModel))]
    [ProducesResponseType((404))]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] EditImagemModel editImagemModel)
    {
        if (editImagemModel == null)
            return BadRequest();

        var imagemEdit = await _service.UpdateAsync(id, editImagemModel);

        if (imagemEdit == null)
            return BadRequest();

        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var imagem = await _service.DeleteAsync(id);

        if (imagem == false)
            return BadRequest();
            
        return NoContent();
    }

}