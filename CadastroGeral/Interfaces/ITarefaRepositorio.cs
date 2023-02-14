using CadastroGeral.Models;

namespace CadastroGeral.Interfaces
{
    public interface ITarefaRepositorio
    {
        List<TarefaModel> BuscarTodasTarefas(int usuarioId);
        TarefaModel ListarPorId(int id);
        TarefaModel Adicionar(TarefaModel tarefa);
        TarefaModel Editar(TarefaModel tarefa);
        TarefaModel Alterar(TarefaModel tarefa);//após relacionamento
        TarefaModel Atualizar(TarefaModel tarefa);
        bool Apagar(int id);
    }
}
