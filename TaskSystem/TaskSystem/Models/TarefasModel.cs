using TaskSystem.Enums;


namespace TaskSystem.Models 
{

    public class TarefasModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public int? usuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}


