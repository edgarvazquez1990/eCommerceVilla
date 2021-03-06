// <auto-generated />
using System;
using Infra.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220406221621_fecha")]
    partial class fecha
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Model.Addresses.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NumExt")
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("Domain.Model.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("Domain.Model.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("Domain.Model.ProductsOrdes.ProductOrder", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("product_order", (string)null);
                });

            modelBuilder.Entity("Domain.Model.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Domain.Model.Addresses.Address", b =>
                {
                    b.HasOne("Domain.Model.Usuarios.Usuario", "Usuario")
                        .WithOne("Address")
                        .HasForeignKey("Domain.Model.Addresses.Address", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Model.Orders.Order", b =>
                {
                    b.HasOne("Domain.Model.Usuarios.Usuario", "Usuario")
                        .WithMany("Orders")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Model.ProductsOrdes.ProductOrder", b =>
                {
                    b.HasOne("Domain.Model.Orders.Order", "Order")
                        .WithMany("ProductsOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Products.Product", "Product")
                        .WithMany("ProductsOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Model.Orders.Order", b =>
                {
                    b.Navigation("ProductsOrders");
                });

            modelBuilder.Entity("Domain.Model.Products.Product", b =>
                {
                    b.Navigation("ProductsOrders");
                });

            modelBuilder.Entity("Domain.Model.Usuarios.Usuario", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
