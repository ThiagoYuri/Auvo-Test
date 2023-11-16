﻿// <auto-generated />
using System;
using Auvo.RH.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Auvo.RH.DAL.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20231116173759_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Auvo.RH.DAL.Models.Departamento", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("Auvo.RH.Models.Colaborador", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("DepartamentoCodigo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.HasIndex("DepartamentoCodigo");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("Auvo.RH.Models.TempoTrabalhado", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<DateTime>("AlmocoFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AlmocoInic")
                        .HasColumnType("datetime2");

                    b.Property<int>("ColaboradorCodigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Saida")
                        .HasColumnType("datetime2");

                    b.Property<float>("ValorHora")
                        .HasColumnType("real");

                    b.HasKey("Codigo");

                    b.HasIndex("ColaboradorCodigo");

                    b.ToTable("TempoTrabalhado");
                });

            modelBuilder.Entity("Auvo.RH.Models.Colaborador", b =>
                {
                    b.HasOne("Auvo.RH.DAL.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Auvo.RH.Models.TempoTrabalhado", b =>
                {
                    b.HasOne("Auvo.RH.Models.Colaborador", "Colaborador")
                        .WithMany("TempoTrabalhado")
                        .HasForeignKey("ColaboradorCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("Auvo.RH.Models.Colaborador", b =>
                {
                    b.Navigation("TempoTrabalhado");
                });
#pragma warning restore 612, 618
        }
    }
}
