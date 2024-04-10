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

        public async Task<TarefasModel> BuscaPorId(int id)
        {
            return await _dbContex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefasModel>> BuscaTodosUsuarios()
        {
            return await _dbContex.Usuarios.ToListAsync();
        }

        public async Task<TarefasModel> AdicionarUsuario(TarefasModel usuario)
        {
           await _dbContex.Usuarios.AddAsync(usuario);
           await _dbContex.SaveChangesAsync();
           return usuario;
        }

        public async Task<TarefasModel> AtualizarUsuario(TarefasModel usuario, int id)
        {
            TarefasModel usuarioPesquisado = await BuscaPorId(id);

            if(usuarioPesquisado == null) 
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado.");
            }
            usuarioPesquisado.Nome = usuario.Nome;
            usuarioPesquisado.Email = usuario.Email;
            _dbContex.Usuarios.Update(usuarioPesquisado);
            await _dbContex.SaveChangesAsync();
            return usuarioPesquisado;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefasModel usuarioParaApagar = await BuscaPorId(id);
            if (usuarioParaApagar == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado.");
            }

            _dbContex.Usuarios.Remove(usuarioParaApagar);
            await _dbContex.SaveChangesAsync();
            return true;
        }

     

    }
}
