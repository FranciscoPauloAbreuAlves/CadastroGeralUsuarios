using CadastroGeral.Data;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;

namespace CadastroGeral.Repositorio
{
//    public class MembroRepositorio : IMembroRepositorio
//    {
//        private readonly BancoContext _bancoContext;

//        //Injeção do método context
//        public MembroRepositorio(BancoContext bancoContext)
//        {
//            _bancoContext = bancoContext;
//        }

//        //Buscar por Login (copiei do UsuarioRepositorio)
//        public MembroModel BuscarPorLogin(string login)
//        {
//            return _bancoContext.Membros.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
//        }

//        //Buscar por Email e Login
//        public MembroModel BuscarPorEmailELogin(string email, string login)
//        {
//            return _bancoContext.Membros.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
//        }

//        //Buscar por ID
//        public MembroModel ListarPorId(int id)
//        {
//            return _bancoContext.Membros.FirstOrDefault(x => x.Id == id);
//        }

//        //Buscar os membros do banco de dados
//        public List<MembroModel> BuscarTodosMembros()
//        {
//            return _bancoContext.Membros.ToList();
//        }

//        //Método adicionar
//        public MembroModel Adicionar(MembroModel membro)
//        {
//            //Gravar no banco de dados
//            membro.DataCadastro = DateTime.Now;
//            membro.SetSenhaHash();
//            _bancoContext.Membros.Add(membro);
//            _bancoContext.SaveChanges();
//            return membro;
//        }
      
//        //Método atualizar
//        public MembroModel Atualizar(MembroModel membro)
//        {
//            MembroModel membroDB = ListarPorId(membro.Id);

//            if (membroDB == null) throw new System.Exception("Houve um erro na atualização do membro!");
//            membroDB.Nome = membro.Nome;
//            membroDB.Email = membro.Email;
//            membroDB.Login = membro.Login;
//            membroDB.Perfil = membro.Perfil;
//            membroDB.DataAtualizacaoCadastro = DateTime.Now;

//            _bancoContext.Membros.Update(membroDB);
//            _bancoContext.SaveChanges();

//            return membroDB;
//        }

//        //Método para trocar nova senha (Copiado do UsuarioRepositorio)
//        public MembroModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
//        {
//            MembroModel membroDB = ListarPorId(alterarSenhaModel.Id);

//            if (membroDB == null) throw new System.Exception("Houve um erro na atualização da senha, membro não encontrado!");
//            if (!membroDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new System.Exception("Senha não confere!");
//            if (membroDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new System.Exception("Nova senha deve ser diferente da senha atual!");

//            membroDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
//            membroDB.DataAtualizacaoCadastro = DateTime.Now;

//            _bancoContext.Membros.Update(membroDB);
//            _bancoContext.SaveChanges();

//            return membroDB;
//        }

//        //Método apagar
//        public bool Apagar(int id)
//        {
//            MembroModel membroDB = ListarPorId(id);

//            if (membroDB == null) throw new System.Exception("Houve um erro na exclusão do membro!");
//            _bancoContext.Membros.Remove(membroDB);
//            _bancoContext.SaveChanges();
//            return true;
//        }

//        UsuarioModel IMembroRepositorio.AlterarSenha(AlterarSenhaModel alterarSenhaModel)
//        {
//            throw new NotImplementedException();
//        }

//        //Conteúdo entrará aqui!
//    }
}
