using OngsLives.Domain.Entidades;
using OngsLives.Domain.Enums;
using OngsLives.Domain.Interfaces.Repository;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;
using OngsLives.Service.Validators;

namespace OngsLives.Service.Services;
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly UsuarioValidator _validator;
    public UsuarioService(IUsuarioRepository repository, UsuarioValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<List<Usuario>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        var usuario = await _repository.GetByIdAsync(id);

        if (usuario == null) return null;

        return usuario;
    }

    public async Task<Usuario> GetByEmailAsync(string email)
    {
        var usuario = await _repository.GetByEmailAsync(email);

        if (usuario == null) return null;

        return usuario;
    }

    public async Task<Usuario> InsertAsync(InputUsuarioModel inputUsuarioModel)
    {
        var usuarioAtivo = false;

        if (inputUsuarioModel.Perfil == EPerfilUsuario.Admin)
        {
            usuarioAtivo = true;
        }

        var usuario = new Usuario 
        (
        inputUsuarioModel.Nome,
        inputUsuarioModel.Login,
        inputUsuarioModel.Senha,
        inputUsuarioModel.Email,
        inputUsuarioModel.Perfil,
        usuarioAtivo
        );

        await _validator.ValidateAsync(usuario);

        await _repository.InsertAsync(usuario);
        
        return usuario;
    }

    public async Task<Usuario> UpdateAsync(int id, EditUsuarioModel editUsuarioModel)
    {
        var usuario = new Usuario
            (
            editUsuarioModel.Nome,
            editUsuarioModel.Login,
            editUsuarioModel.Senha,
            editUsuarioModel.Email,
            editUsuarioModel.Perfil,
            editUsuarioModel.Actived
            );

        await _validator.ValidateAsync(usuario);

        var usuarioEdit = await _repository.GetByIdAsync(id);

        if (usuarioEdit == null) return null;

        usuarioEdit.Id = id;
        usuarioEdit.Nome = editUsuarioModel.Nome;
        usuarioEdit.Email = editUsuarioModel.Email;
        usuarioEdit.Login = editUsuarioModel.Login;
        usuarioEdit.Senha = editUsuarioModel.Senha;
        usuarioEdit.Perfil = editUsuarioModel.Perfil;
        usuarioEdit.Actived = editUsuarioModel.Actived;

        usuarioEdit = await _repository.UpdateAsync(usuarioEdit);

        return usuarioEdit;
    }

    public async Task<bool> UpdateSituationAsync(int id)
    {
        var usuarioEdit = await _repository.GetByIdAsync(id);

        if (usuarioEdit == null) return false;

        usuarioEdit.Actived = (usuarioEdit.Actived == true) ? false: true;

        try
        {
             usuarioEdit = await _repository.UpdateAsync(usuarioEdit);
             return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var usuario = await _repository.GetByIdAsync(id);

        if (usuario == null) return false;
            
        await _repository.DeleteAsync(id);
        return true;
    }
}