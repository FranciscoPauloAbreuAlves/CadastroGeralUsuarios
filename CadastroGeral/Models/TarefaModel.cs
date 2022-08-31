using CadastroGeral.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CadastroGeral.Models
{
    [Table("Tarefas")]
    public class TarefaModel
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite a tarefa")]
        [Column("Tarefa")]
        [Display(Name = "Tarefa")]
        public string Tarefa { get; set; }

        [Required(ErrorMessage = "Digite o sistema associado")]
        [Column("Sistema")]
        [Display(Name = "Sistema")]
        public string Sistema { get; set; }

        [Required(ErrorMessage = "Digite o responsável pela tarefa")]
        [Column("Responsavel")]
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }

        [Required(ErrorMessage = "Digite a situação da tarefa")]
        [Column("Situacao")]
        [Display(Name = "Situação")]
        public TarefaEnum Situacao { get; set; }
        
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacaoCadastro { get; set; }



        //Relacionamentos entre tabelas
        public int? UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
