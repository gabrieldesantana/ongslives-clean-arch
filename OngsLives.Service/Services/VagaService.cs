using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;
using OngsLives.Service.Services;
using OngsLives.Service.Validators;

namespace OngsLives.Service.Services;
public class VagaService : IVagaService
{
    private readonly IVagaRepository _repository;
    private readonly VagaValidator _validator;
    public VagaService(IVagaRepository repository, VagaValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<List<Vaga>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Vaga> GetByIdAsync(int id)
    {
        var vaga = await _repository.GetByIdAsync(id);

        if (vaga == null) return null;

        return vaga;
    }

    public async Task<Vaga> InsertAsync(InputVagaModel inputVagaModel)
    {
        var vaga = new Vaga
       (
       inputVagaModel.IdVoluntario,
       inputVagaModel.IdOng,
       inputVagaModel.Tipo,
       inputVagaModel.Turno,
       inputVagaModel.Descricao,
       inputVagaModel.Habilidade,
       inputVagaModel.DataInicio,
       inputVagaModel.DataFim
       );

        await _validator.ValidateAsync(vaga);

        await _repository.InsertAsync(vaga);

        return vaga;
    }

    public async Task<Vaga> UpdateAsync(int id, EditVagaModel editVagaModel)
    {
        var vaga = new Vaga
            (
            0,
            0,
            editVagaModel.Tipo,
            editVagaModel.Turno,
            editVagaModel.Descricao,
            editVagaModel.Habilidade,
            editVagaModel.DataInicio,
            editVagaModel.DataFim
            );


        await _validator.ValidateAsync(vaga);

        var vagaEdit = await _repository.GetByIdAsync(id);

        if (vagaEdit == null) return null;

        vagaEdit.Id = id;
        vagaEdit.Tipo = editVagaModel.Tipo;
        vagaEdit.Turno = editVagaModel.Turno;
        vagaEdit.Descricao = editVagaModel.Descricao;
        vagaEdit.Habilidade = editVagaModel.Habilidade;
        vagaEdit.DataInicio = editVagaModel.DataInicio;
        vagaEdit.DataFim = editVagaModel.DataFim;
        vagaEdit.Disponivel = editVagaModel.Disponivel;

        vagaEdit = await _repository.UpdateAsync(vagaEdit);

        return vagaEdit;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var vaga = await _repository.GetByIdAsync(id);

        if (vaga == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}