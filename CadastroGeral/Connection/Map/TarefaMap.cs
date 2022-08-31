using CadastroGeral.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroGeral.Connection.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Tarefa).HasMaxLength(100);
            builder.HasOne(x => x.Usuario);
        }
    }
}
