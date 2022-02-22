using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueWeb.Models
{
    public class ClienteModel
    {
        [Key]
        public int IdCliente {get;set;}

        [Required, MaxLength(128)]
        public string Nome {get;set;}

        [MaxLength(128)]
        public string Email {get;set;}
        
        [Required, MaxLength(15)]
        public string Telefone {get;set;}
    }
}