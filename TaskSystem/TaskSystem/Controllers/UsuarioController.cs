using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositorios.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> ListaTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscaTodosUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscaPorId(int id)
        {
            UsuarioModel usuarioPorId = await _usuarioRepositorio.BuscaPorId(id);
            return Ok(usuarioPorId);
        }

        [HttpPost]
        public async Task<ActionResult<List<UsuarioModel>>> CadastraUsuario([FromBody] UsuarioModel usuario)
        {
            UsuarioModel usuarioCadastrado = await _usuarioRepositorio.AdicionarUsuario(usuario);
            return Ok(usuarioCadastrado);
        }

        [HttpPut]
        public async Task<ActionResult<List<UsuarioModel>>> AtualizaUsuario([FromBody] UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioAtualizado = await _usuarioRepositorio.AtualizarUsuario(usuario, id);
            return Ok(usuarioAtualizado);
        }

        [HttpDelete]
        public async Task<ActionResult<List<UsuarioModel>>> DeletaPorId(int id)
        {
            bool usuarioDeletado = await _usuarioRepositorio.Apagar(id);
            return Ok(usuarioDeletado);
        }

    }



}

