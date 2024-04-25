﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiNetDonacionesEF.Context;

#nullable disable

namespace apiNetDonacionesEF.Migrations
{
    [DbContext(typeof(DonacionesContext))]
    [Migration("20240424203554_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("apiNetDonacionesEF.Models.Donacion", b =>
                {
                    b.Property<int>("DonacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonacionId"));

                    b.Property<int>("DonanteId")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.HasKey("DonacionId");

                    b.HasIndex("DonanteId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Donacion", (string)null);
                });

            modelBuilder.Entity("apiNetDonacionesEF.Models.Donante", b =>
                {
                    b.Property<int>("DonanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonanteId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("DonanteId");

                    b.ToTable("Donante", (string)null);
                });

            modelBuilder.Entity("apiNetDonacionesEF.Models.Proyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProyectoId"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyecto", (string)null);
                });

            modelBuilder.Entity("apiNetDonacionesEF.Models.Donacion", b =>
                {
                    b.HasOne("apiNetDonacionesEF.Models.Donante", "Donante")
                        .WithMany("Donaciones")
                        .HasForeignKey("DonanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiNetDonacionesEF.Models.Proyecto", "Proyecto")
                        .WithMany("Donaciones")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donante");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("apiNetDonacionesEF.Models.Donante", b =>
                {
                    b.Navigation("Donaciones");
                });

            modelBuilder.Entity("apiNetDonacionesEF.Models.Proyecto", b =>
                {
                    b.Navigation("Donaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
