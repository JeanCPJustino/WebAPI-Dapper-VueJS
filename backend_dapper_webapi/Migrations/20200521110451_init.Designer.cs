﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_dapper_webapi.Data;

namespace backend_dapper_webapi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200521110451_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend_dapper_webapi.Models.Aluno", b =>
                {
                    b.Property<int>("id_aluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Professorid_professor")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_professor")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_aluno");

                    b.HasIndex("Professorid_professor");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            id_aluno = 1,
                            dataNascimento = new DateTime(1987, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            id_professor = 1,
                            nome = "Mazinho",
                            sobrenome = "Messi Black"
                        },
                        new
                        {
                            id_aluno = 2,
                            dataNascimento = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            id_professor = 1,
                            nome = "Patrick",
                            sobrenome = "Barriga de Cavalo"
                        },
                        new
                        {
                            id_aluno = 3,
                            dataNascimento = new DateTime(1993, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            id_professor = 2,
                            nome = "Deyverson",
                            sobrenome = "Cambalhota"
                        },
                        new
                        {
                            id_aluno = 4,
                            dataNascimento = new DateTime(1992, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            id_professor = 2,
                            nome = "Alceu",
                            sobrenome = "Voadora"
                        },
                        new
                        {
                            id_aluno = 5,
                            dataNascimento = new DateTime(1987, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            id_professor = 3,
                            nome = "Miguel",
                            sobrenome = "Borja"
                        });
                });

            modelBuilder.Entity("backend_dapper_webapi.Models.Professor", b =>
                {
                    b.Property<int>("id_professor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_professor");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            id_professor = 1,
                            nome = "César"
                        },
                        new
                        {
                            id_professor = 2,
                            nome = "Ademir"
                        },
                        new
                        {
                            id_professor = 3,
                            nome = "Edmundo"
                        });
                });

            modelBuilder.Entity("backend_dapper_webapi.Models.Aluno", b =>
                {
                    b.HasOne("backend_dapper_webapi.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("Professorid_professor");
                });
#pragma warning restore 612, 618
        }
    }
}
