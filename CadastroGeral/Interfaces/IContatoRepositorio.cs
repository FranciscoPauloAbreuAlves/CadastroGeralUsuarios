using CadastroGeral.Models;

namespace CadastroGeral.Interfaces
{
    public interface IContatoRepositorio
    {
        //Mudar após relacionamento (int usuarioId)
        List<ContatoModel> BuscarTodosContatosUsuarios(int usuarioId);
        //List<ContatoModel> BuscarTodosContatosMembros(int membroModelId);
        ContatoModel BuscarPorId(int id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
