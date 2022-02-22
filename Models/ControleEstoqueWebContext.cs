using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueWeb.Models
{
    public class ControleDeEstoqueWebContext : DbContext 
    {
        public DbSet<CategoriaModel> Categorias {get; set;}
        public DbSet<ProdutoModel> Produtos {get; set;}
        
         public DbSet<ClienteModel> Clientes {get; set;}

         public DbSet<PedidoModel> Pedidos {get; set;}

        public DbSet<ItemsPedidoModel> ItemsPedido {get; set;}
        public ControleDeEstoqueWebContext(DbContextOptions<ControleDeEstoqueWebContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaModel>().ToTable("Categoria");
            modelBuilder.Entity<ProdutoModel>().ToTable("Produto");
            modelBuilder.Entity<ClienteModel>().ToTable("Cliente");
            modelBuilder.Entity<PedidoModel>().ToTable("Pedido");
            modelBuilder.Entity<ItemsPedidoModel>().ToTable("ItemsPedido");

        }
    }
}