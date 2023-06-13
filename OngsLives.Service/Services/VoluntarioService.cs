using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;
using OngsLives.Service.Validators;

namespace OngsLives.Service.Services;
public class VoluntarioService : IVoluntarioService
{

    private readonly IVoluntarioRepository _repository;
    private readonly VoluntarioValidator _validator;
    public VoluntarioService(IVoluntarioRepository repository, VoluntarioValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<List<Voluntario>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Voluntario> GetByIdAsync(int id)
    {
        var voluntario = await _repository.GetByIdAsync(id);

        if (voluntario == null) return null;

        return voluntario;
    }

    public async Task<Voluntario> GetByEmailAsync(string email)
    {
        var voluntario = await _repository.GetByEmailAsync(email);

        if (voluntario == null) return null;

        return voluntario;
    }

    //public async Task<Voluntario> InsertAsync(InputVoluntarioModel inputVoluntarioModel, AbstractValidator<Voluntario> voaluntarioValidator)
    public async Task<Voluntario> InsertAsync(InputVoluntarioModel inputVoluntarioModel)
    {
        var voluntario = new Voluntario
        (
        inputVoluntarioModel.Nome,
        inputVoluntarioModel.CPF,
        inputVoluntarioModel.DataNascimento,
        inputVoluntarioModel.Escolaridade,
        inputVoluntarioModel.Genero,
        inputVoluntarioModel.Email,
        inputVoluntarioModel.Telefone,
        inputVoluntarioModel.Habilidade,
        inputVoluntarioModel.Endereco
        );

        await _validator.ValidateAsync(voluntario);

        await _repository.InsertAsync(voluntario);

        return voluntario;
    }

    public async Task InsertImagemAsync(Voluntario voluntario)
    {
        if (voluntario == null)
            throw new Exception("Foto sem informações");

        // _repository.AdicionarVaga(ong);
        //_repository.InsertPropAsync(voluntario);
    }

    //public async Task<Voluntario> UpdateAsync(int id, EditVoluntarioModel editVoluntarioModel, AbstractValidator<Voluntario> voluntarioValidator)
    public async Task<Voluntario> UpdateAsync(int id, EditVoluntarioModel editVoluntarioModel)
    {
        var voluntario = new Voluntario(
            "Edit model name",
            "Edita model cpf",
            new DateTime(1900, 01, 01, 23, 59, 59),
            editVoluntarioModel.Escolaridade,
            "Edit model gender",
            editVoluntarioModel.Email,
            editVoluntarioModel.Telefone,
            editVoluntarioModel.Habilidade,
            editVoluntarioModel.Endereco
            );

        //var validator = new VoluntarioValidator();
        //await validator.ValidateAsync(voluntario);
        await _validator.ValidateAsync(voluntario);


        var voluntarioEdit = await _repository.GetByIdAsync(id);

        if (voluntarioEdit == null) return null;

        voluntarioEdit.Id = id;
        voluntarioEdit.Escolaridade = editVoluntarioModel.Escolaridade;
        voluntarioEdit.Email = editVoluntarioModel.Email;
        voluntarioEdit.Telefone = editVoluntarioModel.Telefone;
        voluntarioEdit.Habilidade = editVoluntarioModel.Habilidade;
        voluntarioEdit.Avaliacao = editVoluntarioModel.Avaliacao;
        voluntarioEdit.HorasVoluntaria = editVoluntarioModel.HorasVoluntaria;
        voluntarioEdit.QuantidadeExperiencias = editVoluntarioModel.QuantidadeExperiencias;
        voluntarioEdit.Endereco = editVoluntarioModel.Endereco;

        voluntarioEdit = await _repository.UpdateAsync(voluntarioEdit);

        return voluntarioEdit;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var voluntario = await _repository.GetByIdAsync(id);

        if (voluntario == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }

}