using CadastroGeral.Models;

namespace CadastroGeral.Interfaces
{
    public interface ISessaoUsuario
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
