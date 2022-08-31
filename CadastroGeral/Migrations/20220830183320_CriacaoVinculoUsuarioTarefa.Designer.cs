﻿// <auto-generated />
using System;
using CadastroGeral.Connection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroGeral.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20220830183320_CriacaoVinculoUsuarioTarefa")]
    partial class CriacaoVinculoUsuarioTarefa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CadastroGeral.Models.ContatoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("celular");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("CadastroGeral.Models.TarefaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataAtualizacaoCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Responsavel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Responsavel");

                    b.Property<string>("Sistema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Sistema");

                    b.Property<int>("Situacao")
                        .HasColumnType("int")
                        .HasColumnName("Situacao");

                    b.Property<string>("Tarefa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tarefa");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioModelId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("CadastroGeral.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataAtualizacaoCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CadastroGeral.Models.ContatoModel", b =>
                {
                    b.HasOne("CadastroGeral.Models.UsuarioModel", "Usuario")
                        .WithMany("Contatos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CadastroGeral.Models.TarefaModel", b =>
                {
                    b.HasOne("CadastroGeral.Models.UsuarioModel", null)
                        .WithMany("Tarefas")
                        .HasForeignKey("UsuarioModelId");
                });

            modelBuilder.Entity("CadastroGeral.Models.UsuarioModel", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
