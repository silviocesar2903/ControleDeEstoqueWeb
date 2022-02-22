using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeEstoqueWeb.Migrations
{
    public partial class Versao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsPedidoModel_Produto_IdProduto",
                table: "ItemsPedidoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_ItemsPedidoModel_ItemPedidoIdItemPedido",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsPedidoModel",
                table: "ItemsPedidoModel");

            migrationBuilder.RenameTable(
                name: "ItemsPedidoModel",
                newName: "ItemsPedido");

            migrationBuilder.RenameColumn(
                name: "NoneProduto",
                table: "ItemsPedido",
                newName: "NomeProduto");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsPedidoModel_IdProduto",
                table: "ItemsPedido",
                newName: "IX_ItemsPedido_IdProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsPedido",
                table: "ItemsPedido",
                column: "IdItemPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsPedido_Produto_IdProduto",
                table: "ItemsPedido",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_ItemsPedido_ItemPedidoIdItemPedido",
                table: "Pedido",
                column: "ItemPedidoIdItemPedido",
                principalTable: "ItemsPedido",
                principalColumn: "IdItemPedido",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsPedido_Produto_IdProduto",
                table: "ItemsPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_ItemsPedido_ItemPedidoIdItemPedido",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsPedido",
                table: "ItemsPedido");

            migrationBuilder.RenameTable(
                name: "ItemsPedido",
                newName: "ItemsPedidoModel");

            migrationBuilder.RenameColumn(
                name: "NomeProduto",
                table: "ItemsPedidoModel",
                newName: "NoneProduto");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsPedido_IdProduto",
                table: "ItemsPedidoModel",
                newName: "IX_ItemsPedidoModel_IdProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsPedidoModel",
                table: "ItemsPedidoModel",
                column: "IdItemPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsPedidoModel_Produto_IdProduto",
                table: "ItemsPedidoModel",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_ItemsPedidoModel_ItemPedidoIdItemPedido",
                table: "Pedido",
                column: "ItemPedidoIdItemPedido",
                principalTable: "ItemsPedidoModel",
                principalColumn: "IdItemPedido",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
