using TaskSystem.Enums;


namespace TaskSystem.Models 
{

    public class TarefasModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}


