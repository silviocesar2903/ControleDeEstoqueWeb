using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueWeb.Models
{
    public class ItemsPedidoModel
    {
        [Key]
        public int IdItemPedido {get; set;}

        [ForeignKey("Produto")]
        public int IdProduto {get; set;}

        public ProdutoModel Produto{get; set;}

        //[MaxLength(128)]
        public string NomeProduto {get;set;}
        /*
         get
            {
                if (this.Produto.Nome == null)
                {
                    return this.NomeProduto = "";
                }
                
            }*/
        public float ValorUnitario {
            set{}
            get
            {
               this.ValorUnitario = this.Produto.Preco;
               return this.ValorUnitario;
            }
        }

        [Required]
        public int Quantidade {get;set;}

    }
}