using CadastroGeral.Connection;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroGeral.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        //Construtor de injeção do método context
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        //Buscar por Login (copiei para Membrorepositório)
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        //Buscar por ID
        public UsuarioModel BuscarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        //Buscar por Email e Login
        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        //Buscar os usuários do banco de dados
        public List<UsuarioModel> BuscarTodos()
        {
            //return _bancoContext.Usuarios.Where(x => x.Id == usuarioId).ToList();
            return _bancoContext.Usuarios
                .Include(x => x.Contatos)
                .ToList();
        }

        //Método adicionar
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //Gravar no banco de dados a data cadastro
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }


        //Método editar (verificar!!!)
        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuário!");
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacaoCadastro = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        //Método atualizar
        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuário!");
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacaoCadastro = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        //Método para trocar nova senha (Copiado para MembroRepositorio)
        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = BuscarPorId (alterarSenhaModel.Id);
            
            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização da senha, usuário não encontrado!");
            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new System.Exception("Senha não confere!");
            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new System.Exception("Nova senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacaoCadastro = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        //Método apagar
        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = BuscarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na exclusão do usuário!");
            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }

       //Conteúdo entrará aqui!
    }
}
