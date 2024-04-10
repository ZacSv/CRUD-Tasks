using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositorios.Interfaces;

namespace TaskSystem.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContex _dbContex;

        public UsuarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContex = sistemaTarefasDBContex;
        }

        public async Task<UsuarioModel> BuscaPorId(int id)
        {
            return await _dbContex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscaTodosUsuarios()
        {
            return await _dbContex.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            _dbContex.Usuarios.Add(usuario);
            _dbContex.SaveChanges();
            return usuario;
        }

        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPesquisado = await BuscaPorId(id);

            if(usuarioPesquisado == null) 
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado.");
            }
            usuarioPesquisado.Nome = usuario.Nome;
            usuarioPesquisado.Email = usuario.Email;
            _dbContex.Usuarios.Update(usuarioPesquisado);
            _dbContex.SaveChanges();
            return usuarioPesquisado;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioParaApagar = await BuscaPorId(id);
            if (usuarioParaApagar == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado.");
            }

            _dbContex.Usuarios.Remove(usuarioParaApagar);
            _dbContex.SaveChanges();
            return true;
        }

     

    }
}
