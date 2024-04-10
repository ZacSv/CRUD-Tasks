using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositorios.Interfaces;

namespace TaskSystem.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaTarefasDBContex _dbContex;

        public TarefaRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContex = sistemaTarefasDBContex;
        }

        public async Task<TarefasModel> BuscaTarefaPorId(int id)
        {
            return await _dbContex.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefasModel>> BuscaTodasTarefas()
        {
            return await _dbContex.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefasModel> AdicionarTarefa(TarefasModel tarefa)
        {
           await _dbContex.Tarefas.AddAsync(tarefa);
           await _dbContex.SaveChangesAsync();
           return tarefa;
        }

        public async Task<TarefasModel> AtualizarTarefa(TarefasModel tarefa, int id)
        {
            TarefasModel tarefaPesquisada = await BuscaTarefaPorId(id);

            if(tarefaPesquisada == null) 
            {
                throw new Exception($"Tarefa para o ID:{id} não foi encontrada.");
            }
            tarefaPesquisada.Nome = tarefa.Nome;
            tarefaPesquisada.Descricao = tarefa.Descricao;
            tarefaPesquisada.Status = tarefa.Status;
            tarefaPesquisada.usuarioId = tarefa.usuarioId;

            _dbContex.Tarefas.Update(tarefaPesquisada);
            await _dbContex.SaveChangesAsync();
            return tarefaPesquisada;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefasModel tarefaParaApagar = await BuscaTarefaPorId(id);
            if (tarefaParaApagar == null)
            {
                throw new Exception($"Tarefa para o ID:{id} não foi encontrada.");
            }

            _dbContex.Tarefas.Remove(tarefaParaApagar);
            await _dbContex.SaveChangesAsync();
            return true;
        }

     

    }
}
