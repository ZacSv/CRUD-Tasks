using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositorios.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefasModel>>> ListaTodasTarefas()
        {
            List<TarefasModel> tarefas = await _tarefaRepositorio.BuscaTodasTarefas();
            return Ok(tarefas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TarefasModel>>> BuscaPorId(int id)
        {
            TarefasModel tarefaPorId = await _tarefaRepositorio.BuscaTarefaPorId(id);
            return Ok(tarefaPorId);
        }

        [HttpPost]
        public async Task<ActionResult<List<TarefasModel>>> CadastraTarefa([FromBody] TarefasModel tarefa)
        {
            TarefasModel tarefaCadastrada = await _tarefaRepositorio.AdicionarTarefa(tarefa);
            return Ok(tarefaCadastrada);
        }

        [HttpPut]
        public async Task<ActionResult<List<TarefasModel>>> AtualizaUsuario([FromBody] TarefasModel tarefa, int id)
        {
            TarefasModel tarefaAtualizada = await _tarefaRepositorio.AtualizarTarefa(tarefa, id);
            return Ok(tarefaAtualizada);
        }

        [HttpDelete]
        public async Task<ActionResult<List<TarefasModel>>> DeletaPorId(int id)
        {
            bool tarefaDeletada = await _tarefaRepositorio.Apagar(id);
            return Ok(tarefaDeletada);
        }

    }



}

