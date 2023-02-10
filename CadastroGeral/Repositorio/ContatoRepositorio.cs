using CadastroGeral.Connection;
using CadastroGeral.Interfaces;
using CadastroGeral.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroGeral.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        //Injeção do método context
        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        //Buscar por ID
        public ContatoModel BuscarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        //Buscar todos os usuários do banco de dados
        public List<ContatoModel> BuscarTodos(int usuarioId)
        {
            //return _bancoContext.Contatos.ToList();
            return _bancoContext.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        //Gravar novo contato no banco de dados
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }


        [HttpPost]
        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        //Atualizar contato no banco de dados
        [HttpPost]
        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        //Alterar contato no banco de dados
        [HttpPost]
        public ContatoModel Alterar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        //Apagar contato do banco de dados
        public bool Apagar(int id)
        {
            ContatoModel contatoDB = BuscarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na exclusão do contato!");
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
