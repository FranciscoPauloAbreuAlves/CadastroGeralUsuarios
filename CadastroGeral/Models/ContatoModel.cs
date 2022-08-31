using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroGeral.Models
{
    [Table("Contatos")]
    public class ContatoModel
    {
        [Column("Id")]
        [Display(Name="Código")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do contato")]
        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage ="O email inválido!")]
        [Column("email")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Digite o celulalr do contato")]
        [Phone(ErrorMessage ="Celular inválido!")]
        [Column("celular")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        //Inserir após relacionamento
        public int? UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }

        //public int? MembroId { get; set; }
        //public MembroModel Membro { get; set; }
    }
}
