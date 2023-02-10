using CadastroGeral.Enums;
using CadastroGeral.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroGeral.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário!")]
        //[StringLength(100)]//tamanho do nome
        //[Column("Contato_nome")]//nome da coluna no banco
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuário!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário!")]
        public UsuarioEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário!")]
        public string Senha { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacaoCadastro { get; set; }


        //Validação da senha criptografada
        public bool SenhaValida(string senha)
        {
            //return Senha == senha;//antes da criptografia
            return Senha == senha.GerarHash(); //adicionar após criptografia
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        //Trocar Nova senha
        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
        
        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }


        //Lista de relacionamento entre tabelas do banco dado
        public virtual List<ContatoModel> Contatos { get; set; }
        //public virtual List<UsuarioModel> Usuarios { get; set; } //(08.02.2023)                                                      
        //public virtual List<TarefaModel> Tarefas { get; set; }

        //public int? UsuarioId { get; set; }
        //public UsuarioModel? Usuario { get; set; }
    }
}
