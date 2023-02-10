using CadastroGeral.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroGeral.Data.Map
{
    //Relacionamento entre tabelas
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
           builder.HasKey(x => x.Id);
           builder.HasOne(x => x.Usuario);
           //builder.Property(x => x.Nome).HasMaxLength(100);
           //builder.HasOne(x => x.Membro);
        }
    }
}
