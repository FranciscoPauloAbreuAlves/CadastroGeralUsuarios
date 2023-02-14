using CadastroGeral.Connection;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Mvc;

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

        public TarefaModel ListarPorId(int id)
        {
            return _bancoContext.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public List<TarefaModel> BuscarTodasTarefas(int usuarioId)
        {
            // return _bancoContext.Tarefas.ToList();
            return _bancoContext.Tarefas.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public TarefaModel Adicionar(TarefaModel tarefa)
        {
            //Gravar no banco de dados
            tarefa.DataCadastro = DateTime.Now;
            _bancoContext.Tarefas.Add(tarefa);
            _bancoContext.SaveChanges();
            return tarefa;
        }

        [HttpPost]
        public TarefaModel Editar(TarefaModel editarTarefa)
        {
            TarefaModel tarefaDB = ListarPorId(editarTarefa.Id);

            if (tarefaDB == null) throw new System.Exception("Houve um erro na atualização da tarefa!");
            tarefaDB.Tarefa = editarTarefa.Tarefa;
            tarefaDB.Sistema = editarTarefa.Sistema;
            tarefaDB.Responsavel = editarTarefa.Responsavel;
            tarefaDB.Situacao = editarTarefa.Situacao;
            tarefaDB.DataAtualizacaoCadastro = DateTime.Now;

            _bancoContext.Tarefas.Update(tarefaDB);
            _bancoContext.SaveChanges();
            return tarefaDB;
        }

        [HttpPost]
        public TarefaModel Atualizar(TarefaModel atualizarTarefa)
        {
            TarefaModel tarefaDB = ListarPorId(atualizarTarefa.Id);
            
            if (tarefaDB == null) throw new System.Exception("Houve um erro na atualização da tarefa!");
            tarefaDB.Tarefa = atualizarTarefa.Tarefa;
            tarefaDB.Sistema = atualizarTarefa.Sistema;
            tarefaDB.Responsavel = atualizarTarefa.Responsavel;
            tarefaDB.Situacao = atualizarTarefa.Situacao;
            tarefaDB.DataAtualizacaoCadastro = DateTime.Now;

            _bancoContext.Tarefas.Update(tarefaDB);
            _bancoContext.SaveChanges();

            return tarefaDB;
        }

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

        public bool Apagar(int id)
        {
            TarefaModel tarefaDB = ListarPorId(id);

            if (tarefaDB == null) throw new System.Exception("Houve um erro na exclusão da tarefa!");
            _bancoContext.Tarefas.Remove(tarefaDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}