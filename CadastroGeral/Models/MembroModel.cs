using CadastroGeral.Enums;
using CadastroGeral.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroGeral.Models
{
    //public class MembroModel
    //{
    //    public int Id { get; set; }

    //    [Required(ErrorMessage = "Digite o nome do membro!")]
    //    //[StringLength(100)]//tamanho do nome
    //    //[Column("Contato_nome")]//nome da coluna no banco
    //    public string Nome { get; set; }

    //    [Required(ErrorMessage = "Digite o login do membro!")]
    //    public string Login { get; set; }

    //    [Required(ErrorMessage = "Digite o e-mail do membro!")]
    //    [EmailAddress(ErrorMessage = "Email inválido!")]
    //    public string Email { get; set; }

    //    [Required(ErrorMessage = "Informe o perfil do membro!")]
    //    public MembroEnum? Perfil { get; set; }

    //    [Required(ErrorMessage = "Digite a senha do membro!")]
    //    public string Senha { get; set; }

    //    //[DataType(DataType.Date)]
    //    //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime DataCadastro { get; set; }
    //    public DateTime? DataAtualizacaoCadastro { get; set; }

    //    //Inserir após relacionamento
    //    public virtual List<ContatoModel> Contatos { get; set; }

    //    //Validação da senha criptografada
    //    public bool SenhaValida(string senha)
    //    {
    //        return Senha == senha.GerarHash();
    //    }

    //    public void SetSenhaHash()
    //    {
    //        Senha = Senha.GerarHash();
    //    }

    //    //Trocar Nova senha
    //    public void SetNovaSenha(string novaSenha)
    //    {
    //        Senha = novaSenha.GerarHash();
    //    }

    //    public string GerarNovaSenha()
    //    {
    //        string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
    //        Senha = novaSenha.GerarHash();
    //        return novaSenha;
    //    }
    //}
}



