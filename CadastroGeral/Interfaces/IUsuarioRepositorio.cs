using CadastroGeral.Models;

namespace CadastroGeral.Interfaces
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> BuscarTodos(int usuarioId);
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        UsuarioModel BuscarPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool Apagar(int id);
    }
}
