using TaskSystem.Models;

namespace TaskSystem.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<TarefasModel>> BuscaTodosUsuarios();

        Task<TarefasModel> BuscaPorId(int id);

        Task<TarefasModel> AdicionarUsuario(TarefasModel usuario);

        Task<TarefasModel> AtualizarUsuario(TarefasModel usuario, int id);

        Task<bool> Apagar(int id);

    }
}
