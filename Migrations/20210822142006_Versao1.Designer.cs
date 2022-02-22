﻿// <auto-generated />
using System;
using ControleDeEstoqueWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleDeEstoqueWeb.Migrations
{
    [DbContext(typeof(ControleDeEstoqueWebContext))]
    [Migration("20210822142006_Versao1")]
    partial class Versao1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("ControleDeEstoqueWeb.Models.CategoriaModel", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ControleDeEstoqueWeb.Models.ClienteModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ControleDeEstoqueWeb.Models.ItemsPedidoModel", b =>
                {
                    b.Property<int>("IdItemPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NoneProduto")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<float>("ValorUnitario")
                        .HasColumnType("REAL");

                    b.HasKey("IdItemPedido");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItemsPedidoModel");
                });

            modelBuilder.Entity("ControleDeEstoqueWeb.Models.PedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdItemPedido")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ItemPedidoIdItemPedido")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorCompra")
                        .HasColumnType("REAL");

                    b.HasKey("IdPedido");

                    b.HasIndex("ItemPedidoIdItemPedido");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ControleDeEstoqueWeb.Models.ProdutoModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Estoque")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<float>("Preco")
                        .HasColumnType("REAL");

                    b.HasKey("IdProduto");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ControleDeEstoqueWeb.Models.ItemsPedidoModel", b =>
                {
                    b.HasOne("ControleDeEstoqueWeb.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeEstoqueWeb.Models.PedidoModel", b =>
                {
                    b.HasOne("ControleDeEstoqueWeb.Models.ItemsPedidoModel", "ItemPedido")
                        .WithMany()
                        .HasForeignKey("ItemPedidoIdItemPedido");

                    b.Navigation("ItemPedido");
                });

            modelBuilder.Entity("ControleDeEstoqueWeb.Models.ProdutoModel", b =>
                {
                    b.HasOne("ControleDeEstoqueWeb.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
