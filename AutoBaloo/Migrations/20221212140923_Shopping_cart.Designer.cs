﻿// <auto-generated />
using System;
using AutoBaloo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoBaloo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221212140923_Shopping_cart")]
    partial class Shopping_cart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoBaloo.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AutoBaloo.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("montant")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ReservationId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("AutoBaloo.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateDebut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateFin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<int>("IdVehicule")
                        .HasColumnType("int");

                    b.Property<double>("montantReservation")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdVehicule");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("AutoBaloo.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("montant")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("AutoBaloo.Models.Statut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdVehicule")
                        .HasColumnType("int");

                    b.Property<int>("StatutVehicule")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdVehicule");

                    b.ToTable("Statuts");
                });

            modelBuilder.Entity("AutoBaloo.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateStock")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdVehicule")
                        .HasColumnType("int");

                    b.Property<int>("QteStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdVehicule");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("AutoBaloo.Models.Vehicule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CouleurVehicule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateArrivé")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateConstruct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionVehicule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarqueVehicule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionVehicule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrixVehicule")
                        .HasColumnType("float");

                    b.Property<double>("Prix_par_jour")
                        .HasColumnType("float");

                    b.Property<string>("TypeCarbu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("typeAchat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicules");
                });

            modelBuilder.Entity("AutoBaloo.Models.OrderItem", b =>
                {
                    b.HasOne("AutoBaloo.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoBaloo.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("AutoBaloo.Models.Reservation", b =>
                {
                    b.HasOne("AutoBaloo.Models.Vehicule", "Vehicule")
                        .WithMany("Reservations")
                        .HasForeignKey("IdVehicule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("AutoBaloo.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("AutoBaloo.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("AutoBaloo.Models.Statut", b =>
                {
                    b.HasOne("AutoBaloo.Models.Vehicule", "Vehicule")
                        .WithMany("statuts")
                        .HasForeignKey("IdVehicule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("AutoBaloo.Models.Stock", b =>
                {
                    b.HasOne("AutoBaloo.Models.Vehicule", "Vehicule")
                        .WithMany("Stocks")
                        .HasForeignKey("IdVehicule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("AutoBaloo.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("AutoBaloo.Models.Vehicule", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("statuts");

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
