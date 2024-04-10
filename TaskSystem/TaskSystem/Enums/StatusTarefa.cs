using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,

        [Description("Tarefa em andamento")]
        EmAndamento = 2,

        [Description("Tarefa concluída")]
        Concluido = 3,
    }
}
