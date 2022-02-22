using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueWeb.Models
{
    public class PedidoModel
    {
        [Key]
        public int IdPedido {get; set;}

        [ForeignKey("ItemsPedido")]
        public int IdItemPedido {get; set;}

        public ItemsPedidoModel ItemPedido {get; set;}

        public double ValorCompra {
        set{}
	    get
        {
            return this.ValorCompra += this.ItemPedido.ValorUnitario * this.ItemPedido.Quantidade;
        }}
    }
}
