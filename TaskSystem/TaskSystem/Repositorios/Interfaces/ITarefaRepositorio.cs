using TaskSystem.Models;

namespace TaskSystem.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefasModel>> BuscaTodasTarefas();

        Task<TarefasModel> BuscaTarefaPorId(int id);

        Task<TarefasModel> AdicionarTarefa(TarefasModel tarefa);

        Task<TarefasModel> AtualizarTarefa(TarefasModel tarefa, int id);

        Task<bool> Apagar(int id);

    }
}
