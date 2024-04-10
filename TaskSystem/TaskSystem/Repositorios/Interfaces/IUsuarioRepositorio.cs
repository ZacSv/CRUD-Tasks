using TaskSystem.Models;

namespace TaskSystem.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscaTodosUsuarios();

        Task<UsuarioModel> BuscaPorId(int id);

        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);

        Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id);

        Task<bool> Apagar(int id);

    }
}
