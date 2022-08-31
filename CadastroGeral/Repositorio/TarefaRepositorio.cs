using CadastroGeral.Connection;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;

namespace CadastroGeral.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly BancoContext _bancoContext;

        //Injeção do método context
        public TarefaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        //Método listar as tarefas por ID
        public TarefaModel ListarPorId(int id)
        {
            return _bancoContext.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        //Buscar tarefas do banco de dados
        public List<TarefaModel> BuscarTodasTarefas(int usuarioId)
        {
            // return _bancoContext.Tarefas.ToList();
            return _bancoContext.Tarefas.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        //Método adicionar
        public TarefaModel Adicionar(TarefaModel tarefa)
        {
            //Gravar no banco de dados
            tarefa.DataCadastro = DateTime.Now;
            _bancoContext.Tarefas.Add(tarefa);
            _bancoContext.SaveChanges();
            return tarefa;
        }

        //Método atualizar
        public TarefaModel Atualizar(TarefaModel tarefa)
        {
            TarefaModel tarefaDB = ListarPorId(tarefa.Id);
            
            if (tarefaDB == null) throw new System.Exception("Houve um erro na atualização da tarefa!");
            tarefaDB.Tarefa = tarefa.Tarefa;
            tarefaDB.Sistema = tarefa.Sistema;
            tarefaDB.Responsavel = tarefa.Responsavel;
            tarefaDB.Situacao = tarefa.Situacao;
            tarefaDB.DataAtualizacaoCadastro = DateTime.Now;

            _bancoContext.Tarefas.Update(tarefaDB);
            _bancoContext.SaveChanges();

            return tarefaDB;
        }

        //Método apagar
        public bool Apagar(int id)
        {
            TarefaModel tarefaDB = ListarPorId(id);

            if (tarefaDB == null) throw new System.Exception("Houve um erro na exclusão da tarefa!");
            _bancoContext.Tarefas.Remove(tarefaDB);
            _bancoContext.SaveChanges();
            return true;
        }

        //Método alterar
        public TarefaModel Alterar(TarefaModel tarefa)
        {
            TarefaModel tarefaDB = ListarPorId(tarefa.Id);

            if (tarefaDB == null) throw new System.Exception("Houve um erro na atualização da tarefa!");
            tarefaDB.Tarefa = tarefa.Tarefa;
            tarefaDB.Sistema = tarefa.Sistema;
            tarefaDB.Responsavel = tarefa.Responsavel;
            tarefaDB.Situacao = tarefa.Situacao;
            tarefaDB.DataAtualizacaoCadastro = DateTime.Now;

            _bancoContext.Tarefas.Update(tarefaDB);
            _bancoContext.SaveChanges();

            return tarefaDB;
        }
    }
}