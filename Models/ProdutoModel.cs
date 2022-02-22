using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueWeb.Models
{
    public class ProdutoModel
    {
        [Key]
        public int IdProduto {get; set;}

        [Required, MaxLength(128)]
        public string Nome {get; set;}

        public int Estoque {get; set;}

        public float Preco {get; set;}

        [ForeignKey("Categoria")]
        public int IdCategoria {get; set;}

        public CategoriaModel Categoria {get; set;}
    }
}