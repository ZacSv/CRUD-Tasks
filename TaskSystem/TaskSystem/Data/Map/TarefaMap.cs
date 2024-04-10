using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSystem.Models;
namespace TaskSystem.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefasModel>
    {
        public void Configure(EntityTypeBuilder<TarefasModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasMaxLength(1000);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.usuarioId);
            builder.HasOne(x => x.Usuario);
        }
    }
}
