using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;
using OngsLives.Service.Validators;

namespace OngsLives.Service.Services;

public class ImagemService : IImagemService
{

    private readonly IImagemRepository _repository;
    private readonly ImagemValidator _validator;
    public ImagemService(IImagemRepository repository, ImagemValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }
    public async Task<List<Imagem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Imagem> GetByIdAsync(int id)
    {
        var imagem = await _repository.GetByIdAsync(id);

        if (imagem == null) return null;

        return imagem;
    }

    public async Task<Imagem> InsertAsync(InputImagemModel inputImagemModel)
    {

        var imagem = new Imagem
        (
        inputImagemModel.IdDono,
        inputImagemModel.Nome,
        inputImagemModel.Conteudo
        );

        await _validator.ValidateAsync(imagem);

        await _repository.InsertAsync(imagem);

        return imagem;
    }

    public async Task<Imagem> UpdateAsync(int id, EditImagemModel editImagemModel)
    {
        var imagem = new Imagem
            (
                0,
                editImagemModel.Nome,
                new byte[1]
            );

        await _validator.ValidateAsync(imagem);

        var imagemEdit = await _repository.GetByIdAsync(id);

        if (imagemEdit == null) return null;

        imagemEdit.Id = id;
        imagemEdit.Nome = editImagemModel.Nome;

        imagemEdit = await _repository.UpdateAsync(imagemEdit);

        return imagemEdit;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var imagem = await _repository.GetByIdAsync(id);

        if (imagem == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}