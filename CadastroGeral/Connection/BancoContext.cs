using CadastroGeral.Connection.Map;
using CadastroGeral.Data.Map;
using CadastroGeral.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroGeral.Connection
{
    public class BancoContext : DbContext
    {
        //Construtor
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        //Passar o contexto para dentro de cada tabela do banco:
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        //public DbSet<MembroModel> Membros { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        //Relacionamento de tabelas, depois ir no Console:
        //Add-Migration CriandoVinculoUsuarioContato -Context BancoContext
        //Update-Database -Context BancoContext
        //No banco de dados: "update Contatos set UsuarioId = 1"
        //https://www.youtube.com/watch?v=GzbAUKz7EN4&list=PLJ0IKu7KZpCQKdwRbU7HfXW3raImmghWZ&index=15
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
